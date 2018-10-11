using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PowerDiff.Models.SemanticMerge.Parsing
{
  /// <summary>
  /// key = character position (from beginning of file, starting at 0)
  /// </summary>
  public class CodeRow : IDictionary<int, char>
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="row"></param>
    /// <param name="firstCharacterPostition"></param>
    public CodeRow(string row, int firstCharacterPostition)
    {
      int currentCharacterPostion = firstCharacterPostition;
      foreach (char character in row)
      {
        Add(currentCharacterPostion, character);
        currentCharacterPostion++;
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public override string ToString() =>
      Values.Aggregate(
        "",
        (a, c) => a + c
        );

    #region string

    public bool StartsWith(string value) =>
      ToString().StartsWith(value);

    public int IndexOf(char value) =>
      ToString().IndexOf(value);

    public int IndexOf(string value) =>
      ToString().IndexOf(value);

    public string[] Split(char separator) =>
      ToString().Split(separator);

    public bool Contains(char value) =>
      ToString().Contains(value);

    public bool Contains(string value) =>
      ToString().Contains(value);

    public string Trim() =>
      ToString().Trim();

    public string Trim(char trimChar) =>
      ToString().Trim(trimChar);

    public string ToUpper() =>
      ToString().ToUpper();

    #endregion string

    private readonly SortedDictionary<int, char> characters = new SortedDictionary<int, char>();

    #region IDictionary

    public char this[int key] { get => characters[key]; set => characters[key] = value; }

    public ICollection<int> Keys => ((IDictionary<int, char>)characters).Keys;

    public ICollection<char> Values => ((IDictionary<int, char>)characters).Values;

    public int Count => characters.Count;

    public bool IsReadOnly => ((IDictionary<int, char>)characters).IsReadOnly;

    public void Add(int key, char value)
    {
      characters.Add(key, value);
    }

    public void Add(KeyValuePair<int, char> item)
    {
      ((IDictionary<int, char>)characters).Add(item);
    }

    public void Clear()
    {
      characters.Clear();
    }

    public bool Contains(KeyValuePair<int, char> item)
    {
      return ((IDictionary<int, char>)characters).Contains(item);
    }

    public bool ContainsKey(int key)
    {
      return characters.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<int, char>[] array, int arrayIndex)
    {
      characters.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<int, char>> GetEnumerator()
    {
      return ((IDictionary<int, char>)characters).GetEnumerator();
    }

    public bool Remove(int key)
    {
      return characters.Remove(key);
    }

    public bool Remove(KeyValuePair<int, char> item)
    {
      return ((IDictionary<int, char>)characters).Remove(item);
    }

    public bool TryGetValue(int key, out char value)
    {
      return characters.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IDictionary<int, char>)characters).GetEnumerator();
    }

    #endregion IDictionary
  }
}
