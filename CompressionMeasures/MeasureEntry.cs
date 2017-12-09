using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CompressionMeasures
{
    public class MeasureEntry
    {
        public long JsonSerializationTime { get; set; }
        public long CompressionTime { get; set; }
        public long JsonSize { get; set; }
        public long CompressedSize { get; set; }

        public MeasureEntry(int size)
        {
            var list = new List<User>();
            for (var i = 0; i < size; i++)
            {
                list.Add(new User());
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var json = JsonConvert.SerializeObject(list);
            watch.Stop();
            JsonSerializationTime = watch.ElapsedMilliseconds;

            watch = System.Diagnostics.Stopwatch.StartNew();
            var compressed = new Compress.Compressor<List<User>>().Compress(list);
            watch.Stop();
            CompressionTime = watch.ElapsedMilliseconds;

            JsonSize = GetSize(json);
            CompressedSize = GetSize(compressed);
        }

        private long GetSize(object obj)
        {
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, obj);
                size = s.Length;
            }

            return size;
        }
    }
}
