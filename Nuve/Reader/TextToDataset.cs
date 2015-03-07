using System;
using System.Data;
using System.IO;

namespace Nuve.Reader
{
    internal class TextToDataSet
    {

        /// <summary>
        /// Converts a given delimited file into a dataset. 
        /// Assumes that the first line    
        /// of the text file contains the column names.
        /// </summary>
        /// <param name="stream">The text file as Stream</param>    
        /// <param name="tableName">The name of the 
        /// Table to be made within the DataSet returned</param>
        /// <param name="delimiter">The string to delimit by</param>
        /// <returns>DataSet</returns>  
        /// <see cref="http://www.codeproject.com/Articles/6737/Fill-a-DataSet-from-delimited-text-files"/>
        public static DataSet Convert(Stream stream, string tableName, string delimiter)
        {
            
            StreamReader reader = new StreamReader(stream);

            //Split the first line into the columns       
            string[] columns = reader.ReadLine().Split(delimiter.ToCharArray());

            //The DataSet to Return
            DataSet result = new DataSet();

            //AddSequence the new DataTable to the RecordSet
            result.Tables.Add(tableName);

            //Cycle the colums, adding those that don't exist yet 
            //and sequencing the one that do.
            foreach (string col in columns)
            {
                bool added = false;
                string next = "";
                int i = 0;
                while (!added)
                {
                    //Build the column name and remove any unwanted characters.
                    string columnname = col + next;
                    columnname = columnname.Replace("#", "");
                    columnname = columnname.Replace("'", "");
                    columnname = columnname.Replace("&", "");

                    //See if the column already exists
                    if (!result.Tables[tableName].Columns.Contains(columnname))
                    {
                        //if it doesn't then we add it here and mark it as added
                        result.Tables[tableName].Columns.Add(columnname);
                        added = true;
                    }
                    else
                    {
                        //if it did exist then we increment the sequencer and try again.
                        i++;
                        next = "_" + i.ToString();
                    }
                }
            }

            //Read the rest of the data in the file.        
            string AllData = reader.ReadToEnd();

            //Split off each row at the Carriage Return/Line Feed
            //Default line ending in most windows exports.  
            //You may have to edit this to match your particular file.
            //This will work for Excel, Access, etc. default exports.
            string[] rows = AllData.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            //Now add each row to the DataSet        
            foreach (string r in rows)
            {
                //Split the row at the delimiter.
                string[] items = r.Split(delimiter.ToCharArray());

                //AddSequence the item
                result.Tables[tableName].Rows.Add(items);
            }

            //Return the imported data.        
            return result;
        }
        
    }
}