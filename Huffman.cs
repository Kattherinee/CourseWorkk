using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Course
{
    public class Huffman
    {
        public void CompressFile(string dataFilename, string archFilename)
        {
            byte[] data = File.ReadAllBytes(dataFilename);
            byte[] arch = CompressBytes(data);
            File.WriteAllBytes(archFilename, arch);
        }

        private byte[] CompressBytes(byte[] data)
        {
            int[] freqs = CalculateFreq(data);
            Node root = CreateHuffmanTree(freqs);
            string[] codes = CreateHuffmanCode(root);
            byte[] bits = Compress(data, codes);
            byte[] header = CreateHeader(data.Length, freqs);
            return header.Concat(bits).ToArray();
        }

        private byte[] CreateHeader(int datalength, int[] freqs)
        {
            List<byte> header = new List<byte>();
            //запись длины 4 байта
            header.Add((byte)(datalength & 255));//младшие биты последние 8
            header.Add((byte)((datalength >> 8) & 255));
            header.Add((byte)((datalength >> 16) & 255));
            header.Add((byte)((datalength >> 24) & 255));

            for (int j = 0; j < 256; j++)
                header.Add((byte)freqs[j]);
            return header.ToArray();
        }
        private byte[] Compress(byte[] data, string[] codes)
        {
            List<byte> bits = new List<byte>();
            byte sum = 0;
            byte bit = 1;
            foreach (byte symbol in data)
                foreach (char c in codes[symbol])
                {
                    if (c == '1') sum |= bit;
                    if (bit < 128) bit <<= 1;
                    {
                        bits.Add(sum);
                        sum = 0;
                        bit = 1;
                    }

                }
            if (bit > 1) bits.Add(sum);
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
            return freqs;
        }
        private Node CreateHuffmanTree(int[] freqs)
        {
            //Приоритетная очередь:частота+узел(его номер + частотa)
            PriorityQueue<Node> pq = new PriorityQueue<Node>();
            for (int i = 0; i < 256; i++)
            {
                if (freqs[i] > 0)
                    pq.Enqueue(freqs[i], new Node((byte)i, freqs[i]));
            }
            while (pq.Size() > 1)
            {
                Node bit0 = pq.Dequeue();
                Node bit1 = pq.Dequeue();
                int freq = bit0.freq + bit1.freq;
                Node next = new Node(freq, bit0, bit0);
                pq.Enqueue(freq, next);

            }

            return pq.Dequeue();
        }
    }
}
