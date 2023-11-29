
namespace ConsoleStringCompressor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool for continue withoult exit
            bool _cycleGlobal = true;
            ConsoleKeyInfo _keyInpt;
            string? tempStr;

            Console.WriteLine("Hello! You can compression or decompression your string there.");
            do
            {
                Console.Write("Write the string: ");
                tempStr = Console.ReadLine();
                Console.WriteLine();
            } while (tempStr == null || tempStr == "");
            Console.WriteLine();
            do 
            {
                do
                {
                    Console.WriteLine("Press 'c' to compression or 'd' to decompression string or 'e' to exit.");
                    _keyInpt = Console.ReadKey();
                    Console.WriteLine();
                } while (_keyInpt.KeyChar != 'c' & _keyInpt.KeyChar != 'd' & _keyInpt.KeyChar != 'e');

                if (_keyInpt.KeyChar == 'e')
                {
                    _cycleGlobal = false;
                }
                else
                {
                    switch (_keyInpt.KeyChar)
                    {
                        case 'c':
                            {
                                tempStr = Compression(tempStr);

                            }
                            break;
                        case 'd':
                            {
                                tempStr = Decompression(tempStr);
                            }
                            break;

                    }
                }                
                Console.WriteLine($"result string is:{tempStr}");        

                do 
                {
                    Console.WriteLine("Continue?");
                    Console.WriteLine("(Press 'y' if yes, 'n' if no)");
                    _keyInpt = Console.ReadKey();
                    Console.WriteLine();
                } while (_keyInpt.KeyChar != 'y' && _keyInpt.KeyChar != 'n');

                if (_keyInpt.KeyChar == 'n') 
                { 
                    _cycleGlobal = false; 
                }
                else 
                {
                    do
                    {
                        Console.WriteLine("Change your string?");
                        Console.WriteLine("(Press 'y' if yes, 'n' if no)");
                        _keyInpt = Console.ReadKey();
                                   Console.WriteLine();
                    } while (_keyInpt.KeyChar != 'y' && _keyInpt.KeyChar != 'n');

                    if (_keyInpt.KeyChar == 'y')
                    {
                        do
                        {
                            Console.Write("Write your new string there: ");
                            tempStr = Console.ReadLine();
                            Console.WriteLine();
                        } while (tempStr == null || tempStr == "");
                    }
                }
            } while (_cycleGlobal);
        }

        /// <summary>
        /// Compression {string} to {char plus int of double this char}
        /// </summary>
        /// <param name="tempStr"></param>
        /// <returns></returns>
        private static string Compression(string tempStr)
        {
            if (tempStr != null || tempStr.Length > 1)
            {
                //remember char for can look if char duplicated
                char _tempChar = '-';
                string _tmpStr = "";
                //index how much char duplicated 
                int _i = 1;
                foreach (char c in tempStr)
                {
                    if (c == _tempChar)
                    {
                        _i++;                        
                    }
                    else
                    {
                        if (_i > 1)
                        {
                            _tmpStr = string.Concat(_tmpStr, _i.ToString());
                            _i = 1;
                        }
                        _tmpStr = string.Concat(_tmpStr, c.ToString());

                    }
                    _tempChar = c;
                }

                //int for last symbols
                if (_i > 1) _tmpStr = string.Concat(_tmpStr, _i.ToString());

                return _tmpStr;
            }
            else
            {
                return tempStr;
            }           
            
        }

        /// <summary>
        /// Decompression string from {char plus int double of this char} to {original string}
        /// </summary>
        /// <param name="tempStr"></param>
        /// <returns></returns>
        private static string Decompression( string tempCompressingStr)
        {
            if (tempCompressingStr != null || tempCompressingStr.Length > 1)
            {
                //remember char for write it many times
                char _tmpChr = tempCompressingStr[0];
                string _tmpStr = "";
                //remember how much char duplicated 
                int _dblCount = 0;

                for (int i = 0; i < tempCompressingStr.Length; i++)
                {
                    // if it int
                    if (int.TryParse(tempCompressingStr[i].ToString(), out int _tmpDblChr))
                    {
                        // if previous int too
                        if (_dblCount != 0)
                        {
                            _dblCount = (_dblCount * 10) + _tmpDblChr;
                        }
                        else
                        {
                            _dblCount = _tmpDblChr;
                        }

                        //if it num last symbol in string
                        if(i == tempCompressingStr.Length - 1)
                        {
                            for (int j = 0; j < _dblCount - 1; j++)
                            {
                                _tmpStr = string.Concat(_tmpStr, _tmpChr.ToString());
                            }                            
                        }
                    }
                    //if it char 
                    else
                    {
                        //if previous be int
                        if (_dblCount != 0)
                        {
                            // write previous char [_dblCount - 1] times
                            for (int j = 0; j < _dblCount - 1; j++)
                            {
                                _tmpStr = string.Concat(_tmpStr, _tmpChr.ToString());
                            }                            
                            _tmpChr = tempCompressingStr[i];
                            //write current char
                            _tmpStr = string.Concat(_tmpStr, _tmpChr.ToString());
                            _dblCount = 0;
                        }
                        else
                        {
                            _tmpChr = tempCompressingStr[i];
                            _tmpStr = string.Concat(_tmpStr, _tmpChr.ToString());
                                                      
                        }
                    }                  
                }        
                return _tmpStr;
            }
            else
            {
                return tempCompressingStr;
            }
        }

        
    }
}
