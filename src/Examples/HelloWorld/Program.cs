// See https://aka.ms/new-console-template for more information
using GTMH.S11n;

using HelloWorld;
using HelloWorld.Operations;

var cfg = new DictionaryConfig()
{
  {"Head", "HelloWorld.Operations.Say" },
  {"Head.Normally", "Hello" },
  {"Body.Array-Length", "5" },
  {"Body.0", "HelloWorld.Operations.SPC" },
  {"Body.1", "HelloWorld.Operations.Mumble" },
  {"Body.1.Murmur", "wasting time" },
  {"Body.2", "HelloWorld.Operations.Mumble" },
  {"Body.2.Murmur", "coffee time" },
  {"Body.3", "HelloWorld.Operations.SPC" },
  {"Body.4", "HelloWorld.Operations.Shout" },
  {"Body.4.Loudly", "World" },
  {"Tail", "HelloWorld.Operations.EOM" }
};

var algo = new Algorithm(cfg.ForInit());
//var algo = new Algorithm(
//  new Say("Hello"), 
//  new IOperator[] { new SPC(), new Mumble("wasting time"), new Mumble("coffee time"), new SPC(), new Shout("World") },
//  new EOM()
//  );
//var algo = new Algorithm(new Say("Hello World"), Array.Empty<IOperator>(), null );
/*var algo = new Algorithm(
  new Say("Hello"), 
  new IOperator[] { new SPC(), new Mumble("wasting time"), new Mumble("coffee time"), new SPC(), new Shout("World") },
  new EOM()
  );*/

var s11n = algo.ParseS11n();

algo.Head.Execute();
foreach(var op in algo.Body ) op.Execute();
if ( algo.Tail != null ) algo.Tail.Execute();
