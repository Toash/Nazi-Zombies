using UnityEngine;

public class Doorbuy : MonoBehaviour,IPlayerInteractable
{
	[SerializeField]
	private int cost;
	[SerializeField]
	private string textToDisplay;

	public string InteractText { get; set; }

	private void Awake()
	{
		textToDisplay=textToDisplay.Replace("<cost>", this.cost.ToString());
		InteractText = textToDisplay;
	}

	public void Interact()
	{
		Destroy(this.gameObject);
	}

}
