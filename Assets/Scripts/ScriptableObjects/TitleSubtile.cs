using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Header", menuName = "TitleAndSubtitle")]

public class TitleSubtile : ScriptableObject
{
    [SerializeField]private string title;
    [SerializeField]private string subtile;
    [SerializeField]private Image backgroundImage;


    public string Title { get { return title; } }

    public string Subtile { get {  return subtile; } }

    public Image BackgroundImage { get {  return backgroundImage; } }
}
