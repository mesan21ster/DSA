public class Solution
{
    //Design a data structure that supports insert, delete, search, and getRandom in constant time.

    Dictionary<int, int> dict = new Dictionary<int, int>();
    List<int> list = new List<int>();
    Random rand = new Random();

    public bool insert(int val)
    {
        if (dict.ContainsKey(val))
        {
            return false;
        }
        dict[val] = list.Count; // store the index of the value in the list
        list.Add(val);
        return true;
    }

    public bool search(int val)
    {
        if (dict.ContainsKey(val))
        {
            return true;
        }
        return false;
    }

    public int getRandom()
    {
        return list[rand.Next(list.Count)];// get a random index and return the value at that index
    }

    public bool remove(int val)
    {
        if (!dict.ContainsKey(val))
        {
            return false;
        }

        int index = dict[val]; // get the index of the element to remove
        dict.Remove(val); // remove it from the dictionary
        if (index < list.Count - 1)// if it's not the last element, swap it with the last element
        {
            int lastElement = list[list.Count - 1];// get the last element
            list[index] = lastElement;// move the last element to the index of the element to remove
            dict[lastElement] = index;// update the index of the last element in the dictionary
        }
        list.RemoveAt(list.Count - 1);// remove the last element
        return true;
    }
    public void print()
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

}

internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        solution.insert(3);
        solution.insert(4);
        solution.insert(5);
        solution.insert(6);

        solution.print();
        solution.search(4);

        solution.getRandom();


        solution.remove(4);
        solution.print();

        Console.ReadLine();
    }
}