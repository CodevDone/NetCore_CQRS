using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Test
{
    public class TestCopilot
    {
        // You are given an array people where people[i] is the weight of the ith person, and an infinite number of boats where each boat can carry a maximum weight of limit. Each boat carries at most two people at the same time, provided the sum of the weight of those people is at most limit.
        // Return the minimum number of boats to carry every given person.

        // Example 1:
        // Input: people = [1,2], limit = 3
        // Output: 1
        // Explanation: 1 boat (1, 2)

        public int NumOfBoats(int[] people, int limit)
        {
            var sortedPeople = people.OrderBy(x => x).ToArray();
            var numOfBoats = 0;
            var currentBoatWeight = 0;
            currentBoatWeight = 0;
            var i = 0;
            while (i < sortedPeople.Length)
            {
                currentBoatWeight += sortedPeople[i];
                if (currentBoatWeight <= limit)
                {
                    i++;
                }
                else
                {
                    numOfBoats++;
                    currentBoatWeight = 0;
                }
            }
            if (currentBoatWeight > 0)
            {
                numOfBoats++;
            }
            return numOfBoats;
        }

        // revibing a .mp3 file from a remote server
        // Given a file size, return the number of chunks that need to be downloaded to complete the file.
        // You can assume that the file will be downloaded in one piece.
        // Example 1:
        // Input: fileSize = 4
        // Output: 2
        // Explanation: There are 2 ways to download the file. Both use 1 chunk each.
        // Example 2:
        // Input: fileSize = 5
        // Output: 3
        // Explanation: There are 3 ways to download the file. The first 2 use 1 chunk each and the last one uses 2 chunks.
        // Example 3:
        // Input: fileSize = 6
        // Output: 5
        // Explanation: There are 5 ways to download the file. The first 4 use 1 chunk each and the last one uses 2 chunks.
        // Example 4:
        // Input: fileSize = 7
        // Output: 8
        // Explanation: There are 8 ways to download the file. The first 7 use 1 chunk each and the last one uses 3 chunks.
        // Example 5:
        // Input: fileSize = 8
        // Output: 13
        // Explanation: There are 13 ways to download the file. The first 8 use 1 chunk each and the last one uses 4 chunks.
        // Constraints:
        // 1 <= fileSize <= 10^7
        public int NumOfChunks(int fileSize)
        {
            var numOfChunks = 0;
            var chunkSize = 1;
            while (fileSize > 0)
            {
                numOfChunks++;
                fileSize -= chunkSize;
                chunkSize++;
            }
            return numOfChunks;
        }


    }
}