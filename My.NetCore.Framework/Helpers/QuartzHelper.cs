using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Helpers
{
    public class QuartzHelper
    {
        private static NameValueCollection properties;
        private static IScheduler scheduler;
        private static ISchedulerFactory schedulerFactory;

        static QuartzHelper()
        {
            try
            {
                properties = new NameValueCollection();
                properties["quartz.scheduler.instanceName"] = "RemoteServerSchedulerClient";

                // 设置线程池
                properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
                properties["quartz.threadPool.threadCount"] = "5";
                properties["quartz.threadPool.threadPriority"] = "Normal";

                // set db info
                properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
                properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
                properties["quartz.jobStore.dataSource"] = "myDS";
                properties["quartz.dataSource.myDS.connectionString"] = "Server=10.28.88.238;Port=3306;Database=ha_test;Uid=root;Pwd=3$%*(k/{]rtEE5;";
                properties["quartz.dataSource.myDS.provider"] = "MySql-50";

                // 远程输出配置
                properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
                properties["quartz.scheduler.exporter.port"] = "5555";
                properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";
                properties["quartz.scheduler.exporter.channelType"] = "tcp";
                properties["quartz.scheduler.exporter.channelName"] = "httpQuartz";

                schedulerFactory = new StdSchedulerFactory(properties);

                scheduler = schedulerFactory.GetScheduler().Result;

                scheduler.Start();

                Console.WriteLine("Server 启动成功!");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 时间间隔执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="seconds">时间间隔(单位：秒)</param>
        public static async Task<bool> ExecuteInterval<T>(int seconds) where T : IJob
        {
            try
            {
                //2、创建工作任务
                IJobDetail job = JobBuilder.Create<T>().Build();
                // 3、创建触发器
                ITrigger trigger = TriggerBuilder.Create().StartNow().
                    WithSimpleSchedule(x => x.WithIntervalInSeconds(seconds)
                                        //x.WithIntervalInMinutes(1)
                                        .RepeatForever())
                                        .Build();
                //4、将任务加入到任务池
                await scheduler.ScheduleJob(job, trigger);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        /// <summary>
        /// 指定时间执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="cronExpression">cron表达式，即指定时间点的表达式</param>
        public static async Task<bool> ExecuteByCron<T>(string cronExpression) where T : IJob
        {
            try
            {
                //2、创建工作任务
                IJobDetail job = JobBuilder.Create<T>().Build();
                //3、创建触发器
                ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                       .StartNow()
                                       .WithCronSchedule(cronExpression)
                                       .Build();
                //4、将任务加入到任务池
                await scheduler.ScheduleJob(job, trigger);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
