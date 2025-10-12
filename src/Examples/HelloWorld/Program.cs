using GTMH.S11n;
using GTMH.S11n.TypeResolution;

using HelloWorld;

var cfg = new DictionaryConfig()
{
  {"Head", "HelloWorld.Say" },
  {"Head.Value", "Hello" },
  {"Body.Array-Length", "5" },
  {"Body.0", "HelloWorld.SPC" },
  {"Body.1", "HelloWorld.Mumble" },
  {"Body.1.Value", "wasting time" },
  {"Body.2", "HelloWorld.Mumble" },
  {"Body.2.Value", "coffee time" },
  {"Body.3", "HelloWorld.SPC" },
  {"Body.4", "HelloWorld.Shout" },
  {"Body.4.Value", "World" },
  {"Tail", "HelloWorld.EOM" }
};

var algo = new Algorithm(cfg.ForInit(new CurrLoadedAssemblies()));

algo.Head.Execute();
foreach(var op in algo.Body ) op.Execute();
if ( algo.Tail != null ) algo.Tail.Execute();
