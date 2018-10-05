using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PowerDiff.Models.SemanticMerge.Parsing
{
  /// <summary>
  /// key = row number (starting at 1)
  /// </summary>
  public class CodeFile : IDictionary<int, CodeRow>
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="fileConents"></param>
    public CodeFile(string[] fileConents)
    {
      int currentCharacterPosition = 0;
      for (int i = 0; i < fileConents.Length; i++)
      {
        string line = fileConents[i] + ((i + 1 == fileConents.Length) ? "" : Environment.NewLine);
        Add(i + 1, new CodeRow(line, currentCharacterPosition));
        currentCharacterPosition += line.Length;
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public override string ToString() =>
      Values.Aggregate(
        "",
        (a, r) => a + r
        );

    private readonly SortedDictionary<int, CodeRow> rows = new SortedDictionary<int, CodeRow>();

    #region IDictionary

    public CodeRow this[int key] { get => rows[key]; set => rows[key] = value; }

    public ICollection<int> Keys => ((IDictionary<int, CodeRow>)rows).Keys;

    public ICollection<CodeRow> Values => ((IDictionary<int, CodeRow>)rows).Values;

    public int Count => rows.Count;

    public bool IsReadOnly => ((IDictionary<int, CodeRow>)rows).IsReadOnly;

    public void Add(int key, CodeRow value)
    {
      rows.Add(key, value);
    }

    public void Add(KeyValuePair<int, CodeRow> item)
    {
      ((IDictionary<int, CodeRow>)rows).Add(item);
    }

    public void Clear()
    {
      rows.Clear();
    }

    public bool Contains(KeyValuePair<int, CodeRow> item)
    {
      return ((IDictionary<int, CodeRow>)rows).Contains(item);
    }

    public bool ContainsKey(int key)
    {
      return rows.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<int, CodeRow>[] array, int arrayIndex)
    {
      rows.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<int, CodeRow>> GetEnumerator()
    {
      return ((IDictionary<int, CodeRow>)rows).GetEnumerator();
    }

    public bool Remove(int key)
    {
      return rows.Remove(key);
    }

    public bool Remove(KeyValuePair<int, CodeRow> item)
    {
      return ((IDictionary<int, CodeRow>)rows).Remove(item);
    }

    public bool TryGetValue(int key, out CodeRow value)
    {
      return rows.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IDictionary<int, CodeRow>)rows).GetEnumerator();
    }

    #endregion IDictionary
  }
}