// See https://aka.ms/new-console-template for more information
using GTMH.S11n;

using HelloWorld;

var cfg = new DictionaryConfig()
{
  {"Head", "HelloWorld.Say" },
  {"Head.Normally", "Hello" },
  {"Body.Array-Length", "5" },
  {"Body.0", "HelloWorld.SPC" },
  {"Body.1", "HelloWorld.Mumble" },
  {"Body.1.Murmur", "wasting time" },
  {"Body.2", "HelloWorld.Mumble" },
  {"Body.2.Murmur", "coffee time" },
  {"Body.3", "HelloWorld.SPC" },
  {"Body.4", "HelloWorld.Shout" },
  {"Body.4.Loudly", "World" },
  {"Tail", "HelloWorld.EOM" }
};

var algo = new Algorithm(cfg.ForInit());

algo.Head.Execute();
foreach(var op in algo.Body ) op.Execute();
if ( algo.Tail != null ) algo.Tail.Execute();
