using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;


namespace WU15.DesignPatterns.Singelton.Core.TaskManager
{
    class ImportRssFeedTask : ITask
    {
        private string url;

        public ImportRssFeedTask(string url)
        {
            this.url = url;
        }

        public void Execute()
        {
            var reader = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(reader); // In System.ServiceModel.
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                var subject = item.Title.Text;
                var summary = item.Summary.Text;

                // TODO: Save to some database

                Console.WriteLine("{0}{1}", subject, summary);
            }
        }
    }
}
