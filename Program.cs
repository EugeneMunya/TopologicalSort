using System;
using System.Collections.Generic;
using System.Collections;
namespace toplogicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodes = 6;
            Graph tSort = new Graph(nodes);
            //adding edges
            tSort.AddEdges(0,1);
            tSort.AddEdges(0,2);
            tSort.AddEdges(1,3);
            tSort.AddEdges(1,4);
            tSort.AddEdges(2,4);
            tSort.AddEdges(3,5);
            tSort.AddEdges(4,5);

         foreach (var item in tSort.TopologicalSort())
            {
                Console.Write(" ");
                Console.Write(item);
            }

        
           
           

        }
    }

    class Graph{
        public List<List<int>> adjList;
        public Dictionary<int,int> incomingDegree;
        public Queue<int> zeroIntryNode;
        public ArrayList result;
        
        public Graph(int nVert){
            adjList= new List<List<int>>();
            incomingDegree = new Dictionary<int, int>();
            zeroIntryNode = new Queue<int>();
            result = new ArrayList();
          for (int i = 0; i < nVert; i++)
          {
              adjList.Insert(i,new List<int>());
              incomingDegree.Add(i,0);
              
          }
        }

        public void AddEdges(int start, int end){
            adjList[start].Add(end);
             incomingDegree[end]+=1;
        }

        public ArrayList TopologicalSort(){
            foreach (var entry in incomingDegree)
            {
                if(entry.Value==0)
                {
                    zeroIntryNode.Enqueue(entry.Key);
                }
            }
            while (zeroIntryNode.Count !=0){
                int firstOut = zeroIntryNode.Dequeue();
                result.Add(firstOut);
                List<int> connectNodes = adjList[firstOut];
               foreach (var item in connectNodes)
               {
                   incomingDegree[item]-=1;
                   if(incomingDegree[item]==0){
                       zeroIntryNode.Enqueue(item);
                   }
               }
            }
            
            return result;
        }


    }
}
