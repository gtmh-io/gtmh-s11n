using GTMH.S11n;

using HelloWorldStateful;

using System.Text;

var cfg = new DictionaryConfig()
{
  {"Head", "HelloWorldStateful.Say" },
  {"Head.Value", "Hello" },
  {"Body.Array-Length", "5" },
  {"Body.0", "HelloWorldStateful.SPC" },
  {"Body.1", "HelloWorldStateful.Mumble" },
  {"Body.1.Value", "wasting time" },
  {"Body.2", "HelloWorldStateful.Mumble" },
  {"Body.2.Value", "coffee time" },
  {"Body.3", "HelloWorldStateful.SPC" },
  {"Body.4", "HelloWorldStateful.Shout" },
  {"Body.4.Value", "World" },
  {"Tail", "HelloWorldStateful.EOM" }
};

var algo = new Algorithm(cfg.ForInit());
var state = new StringBuilder();
algo.Execute(state);
Console.WriteLine(state);

