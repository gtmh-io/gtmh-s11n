// See https://aka.ms/new-console-template for more information
using GTMH.S11n;

using HelloWorld;

var cfg = new DictionaryConfig()
{
  { "Header", "Say" }
};

var algo = new Algorithm(cfg.ForInit());

algo.Header.Execute();
foreach(var op in algo.Body ) op.Execute();
if ( algo.Footer != null ) algo.Footer.Execute();
