using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ColinChang.ConfigurationHelper.Core
{
    public class ConfigurationManager
    {
        /// <summary>
        /// 配置Root节点
        /// 读取一级节点：ConfigUtil.Configuration["nodeName"],读取多级节点：ConfigUtil.Configuration["node1:node2"]
        /// </summary>
        public static IConfiguration Configuration { get; }

        /// <summary>
        /// 读取CommandLine配置。
        /// </summary>
        /// <param name="cmdParameter">CommandLine参数名</param>
        public string this[string cmdParameter] => _cmdConfiguration[cmdParameter];

        private static IServiceCollection _services;
        private IConfiguration _cmdConfiguration;

        static ConfigurationManager()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            _services = new ServiceCollection();
        }

        /// <summary>
        /// 创建用于"读取CommandLine配置"的对象
        /// </summary>
        /// <param name="args">AddCommandLine args</param>
        public ConfigurationManager(string[] args)
        {
            _cmdConfiguration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="keys">节点名称序列</param>
        /// <returns>配置值</returns>
        public static string GetAppSettings(params string[] keys)
        {
            if (keys == null || keys.Length <= 0)
                return null;

            return Configuration[string.Join(":", keys)];
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="key">节点名称</param>
        /// <typeparam name="T">配置对象类型</typeparam>
        /// <returns>配置对象</returns>
        public static T GetAppSettings<T>(string key) where T : class, new()
        {
            return _services.Configure<T>(Configuration.GetSection(key)).BuildServiceProvider()
                .GetService<IOptionsSnapshot<T>>().Value;
        }
    }
}