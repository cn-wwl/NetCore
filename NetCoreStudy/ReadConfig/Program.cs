using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace ReadConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.从json文件中读取数据
            ReadJsonFile();

            //2.从xml文件中读取数据
            ReadXmlFile();

            //3.从内存中读取数据
            ReadMemory();

            //4.从json文件中 映射配置对象获取数据
            ReadJsonFileObjectBind();

            Console.ReadKey();
        }

        public static void ReadJsonFile()
        {
            //1.新建一个appsetting.josn文件

            //2.引用nuget包 Microsoft.Extensions.Configuration.Json

            //3.构建对象(加载json配置文件，然后使用Build方法构建)
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                                .AddJsonFile("appsetting.json").Build();

            //4.读取相关配置参数 读取某个子节点的方式 【父节点:子节点】
            var platform = configuration["platform"];
            var account = configuration["Login:account"];
            var password = configuration["Login:password"];
            Console.WriteLine($"Json文件：平台：{platform}，账号：{account}，密码：{password}");

        }

        public static void ReadXmlFile()
        {
            //1.新建一个appsetting.xml

            //2.引用nuget包 Microsoft.Extensions.Configuration.Xml

            //3.构建对象(加载xml配置文件，然后使用Build方法构建)
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                                .AddXmlFile("appsetting.xml").Build();

            //4.读取相关配置参数 读取某个子节点的方式 【父节点:子节点】
            var platform = configuration["platform"];
            var account = configuration["Login:account"];
            var password = configuration["Login:password"];
            Console.WriteLine($"Xml文件：平台：{platform}，账号：{account}，密码：{password}");

        }

        public static void ReadMemory()
        {
            //1.创建数据源
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("platform", "GitHub"));
            data.Add(new KeyValuePair<string, string>("Address", "https://www.github.com"));

            //2.构建对象
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                                .AddInMemoryCollection(data).Build();

            //3.读取数据
            var platform = configuration["platform"];
            var Address = configuration["Address"]; 
            Console.WriteLine($"内存数据：平台：{platform}，地址：{Address}");

        }
         
        public static void ReadJsonFileObjectBind()
        {
            //1.构建对象
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                                .AddJsonFile("appsetting.json").Build();

            //2.引用nuget包 Microsoft.Extensions.Configuration.Binder

            //3.创建映射对象
            appsetting appsetting = new appsetting();
            configuration.Bind(appsetting);

            var platform = appsetting.platform;
            var Address = appsetting.Address; 
            Console.WriteLine($"Json文件对象映射获取：平台：{platform}，地址：{Address}");  
        }
    }
}
