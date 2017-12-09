using System;
using System.Collections.Generic;
using Commando;
using Commando.Colors.Textwriter;
using Newtonsoft.Json;

namespace CompressionMeasures
{
    class Program
    {
        static void Main(string[] args)
        {
            var one = new MeasureEntry(1);
            var ten = new MeasureEntry(10);
            var hundred = new MeasureEntry(100);
            var thousand = new MeasureEntry(1000);
            var tenThousand = new MeasureEntry(10000);
            var hundredThousand = new MeasureEntry(100000);
            var oneMillion = new MeasureEntry(1000000);

            CommandoTextWriter.Use();
            var table = new Commando.Table.TablePrinter("List entries", "JSON size", "Compressed size");
            table.AddRow("1",
                ConvertToUnit(one.JsonSize),
                ConvertToUnit(one.CompressedSize));
            table.AddRow("10",
                ConvertToUnit(ten.JsonSize),
                ConvertToUnit(ten.CompressedSize));
            table.AddRow("100",
                ConvertToUnit(hundred.JsonSize),
                ConvertToUnit(hundred.CompressedSize));
            table.AddRow("1000",
                ConvertToUnit(thousand.JsonSize),
                ConvertToUnit(thousand.CompressedSize));
            table.AddRow("10 000",
                ConvertToUnit(tenThousand.JsonSize),
                ConvertToUnit(tenThousand.CompressedSize));
            table.AddRow("100 000",
                ConvertToUnit(hundredThousand.JsonSize),
                ConvertToUnit(hundredThousand.CompressedSize));
            table.AddRow("1 000 000",
                ConvertToUnit(oneMillion.JsonSize),
                ConvertToUnit(oneMillion.CompressedSize));
            table.Print();
            Console.ReadKey();
        }

        static string ConvertToUnit(long value)
        {
            return SizeSuffix(value);
        }



        /// <summary>
        /// Credits: https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc/14488941#14488941
        /// </summary>
        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        /// <summary>
        /// Credits: https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc/14488941#14488941
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }
    }
}
