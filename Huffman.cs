using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Course
{
    public class Huffman
    {
        public void CompressFile(string dataFilename, string archFilename)
        {
            try
            {
                byte[] data = File.ReadAllBytes(dataFilename);
                byte[] arch = CompressBytes(data);
                File.WriteAllBytes(archFilename, arch);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Недостаточно памяти для обработки файла. Увеличьте доступную память или используйте другой способ обработки.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сжатии файла: {ex.Message}");
            }
            
        }

        public void DecompressFile(string archFilename, string dataFilename)
        {
            try
            {
                byte[] arch = File.ReadAllBytes(archFilename);
                byte[] data = DecompressBytes(arch);
                File.WriteAllBytes(dataFilename, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при распаковке файла: {ex.Message}");
            }
        }

        private byte[] DecompressBytes(byte[] arch)
        {
            if (arch == null || arch.Length < 4)
            {
                Console.WriteLine("Неверный формат архивного файла.");
                return null;
            }

            ParseHeader(arch, out int dataLength, out int startIndex, out int[] freqs);

            if (startIndex < 0 || dataLength < 0 || dataLength > arch.Length - startIndex)
            {
                Console.WriteLine("Неверный формат архивного файла.");
                return null;
            }

            Node root = CreateHuffmanTree(freqs);
            if (root == null)
            {
                Console.WriteLine("Ошибка при построении дерева Хаффмана.");
                return null;
            }

            byte[] data = Decompress(arch, startIndex, dataLength, root);
            return data;
        }

        private byte[] Decompress(byte[] arch, int startIndex, int dataLength, Node root)
        {
            int size = 0;
            Node curr = root;
            List<byte> data = new List<byte>();
            for (int j = startIndex; j < arch.Length; j++)
                for (int bit = 1; bit <= 128; bit <<= 1)
                {
                    bool zero = (arch[j] & bit) == 0;
                    if (zero)
                        curr = curr.bit0;
                    else
                        curr = curr.bit1;
                    if (curr.bit0 != null)
                        continue;
                    if (size++ < dataLength)
                        data.Add(curr.symbol);
                    curr = root;

                }
            return data.ToArray();
        }

        private void ParseHeader(byte[] arch, out int dataLength, out int startIndex, out int[] freqs)
        {
            dataLength = arch[0] |
                        (arch[1] << 8) |
                        (arch[1] << 16) |
                        (arch[1] << 24);
            freqs = new int[256];
            for (int j = 0; j < 256; j++)
                freqs[j] = arch[4 + j];
            startIndex = 4 + 256;

        }

        private byte[] CompressBytes(byte[] data)
        {
            int[] freqs = CalculateFreq(data);
            byte[] head = CreateHeader(data.Length, freqs);
            Node root = CreateHuffmanTree(freqs);
            string[] codes = CreateHuffmanCode(root);
            byte[] bits = Compress(data, codes);
            return head.Concat(bits).ToArray();
        }

        private byte[] CreateHeader(int dataLength, int[] freqs)
        {
            List<byte> head = new List<byte>();
            head.Add((byte)(dataLength & 255));
            head.Add((byte)((dataLength >> 8) & 255));
            head.Add((byte)((dataLength >> 16) & 255));
            head.Add((byte)((dataLength >> 24) & 255));
            for (int j = 0; j < 256; j++)
                head.Add((byte)freqs[j]);
            return head.ToArray();
        }

        private Node CreateHuffmanTree(int[] freqs)
        {
            PriorityQueue<Node> pq = new PriorityQueue<Node>();
            for (int j = 0; j < 256; j++)
                if (freqs[j] > 0)
                    pq.Enqueue(freqs[j], new Node((byte)j, freqs[j]));
            while (pq.Size() > 1)
            {
                Node bit0 = pq.Dequeue();
                Node bit1 = pq.Dequeue();
                int freq = bit0.freq + bit1.freq;
                Node next = new Node(bit0, bit1, freq);
                pq.Enqueue(freq, next);
            }
            return pq.Dequeue();
        }

        private byte[] Compress(byte[] data, string[] codes)
        {
            List<byte> bits = new List<byte>();
            byte sum = 0;
            byte bit = 1;
            foreach (byte symbol in data)
                foreach (char c in codes[symbol])
                {
                    if (c == '1')
                        sum |= bit;
                    if (bit < 128)
                        bit <<= 1;
                    else
                    {
                        bits.Add(sum);
                        sum = 0;
                        bit = 1;
                    }
                }
            if (bit > 1)
                bits.Add(sum);
            return bits.ToArray();
        }

        private string[] CreateHuffmanCode(Node root)
        {
            string[] codes = new string[256];
            Next(root, "");
            return codes;
            void Next(Node node, string code)
            {
                if (node.bit0 == null)
                    codes[node.symbol] = code;
                else
                {
                    Next(node.bit0, code + "0");
                    Next(node.bit1, code + "1");
                }
            }
        }
        private int[] CalculateFreq(byte[] data)
        {
            int[] freqs = new int[256];
            foreach (byte d in data)
                freqs[d]++;
            NormalizeFreqs();
            return freqs;

            void NormalizeFreqs()
            {
                int max = freqs.Max();
                if (max <= 255) return;
                for (int j = 0; j < 256; j++)
                    if (freqs[j] > 0)
                        freqs[j] = 1 + freqs[j] * 255 / (max + 1);
            }

        }


    }
}
