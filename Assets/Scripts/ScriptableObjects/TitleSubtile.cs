using UnityEngine;

[CreateAssetMenu(fileName = "Header", menuName = "TitleAndSubtitle")]
public class TitleSubtile : ScriptableObject
{
    [SerializeField]private string title;
    [SerializeField]private string subtile;

    public string Title { get { return title; } }

    public string Subtile { get {  return subtile; } }
}
