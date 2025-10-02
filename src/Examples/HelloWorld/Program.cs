// See https://aka.ms/new-console-template for more information
using GTMH.S11n;

using HelloWorld;
using HelloWorld.Operations;

/*var cfg = new DictionaryConfig()
{
  { "Head", "Say" }
};

var algo = new Algorithm(cfg.ForInit());*/
//var algo = new Algorithm(
//  new Say("Hello"), 
//  new IOperator[] { new SPC(), new Mumble("wasting time"), new Mumble("coffee time"), new SPC(), new Shout("World") },
//  new EOM()
//  );
var algo = new Algorithm(new Say("Hello World"), Array.Empty<IOperator>(), null );

var slln = algo.ParseS11n();

algo.Head.Execute();
foreach(var op in algo.Body ) op.Execute();
if ( algo.Tail != null ) algo.Tail.Execute();
