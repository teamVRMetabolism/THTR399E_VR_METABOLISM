using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EdgeUIElement : UIElement
{
    public Text LabelText;
    public Text DescriptionText;

    public Text QIDText;
    public Text EnergyConsumedText;
    public Text EnergyProducedText;
    public Text GibbsFreeEnergyText;

    public GameObject AuxUI;
    public Text AuxLabelText;
    public Text AuxDescriptionText;

    public Text AuxQIDText;
    public Text AuxEnergyConsumedText;
    public Text AuxEnergyProducedText;
    public Text AuxGibbsFreeEnergyText;

    override public void UpdateUI()
    {
        // Update Edge UI Element
        Debug.Log("Updating Edge UI");

        LabelText.text = ((Card)DataReference).Label;
        DescriptionText.text = ((Card)DataReference).Description;
        QIDText.text = ((Card)DataReference).QID;
        EnergyConsumedText.text = ((Card)DataReference).EnergyConsumed;
        EnergyProducedText.text = ((Card)DataReference).EnergyProduced;
        GibbsFreeEnergyText.text = ((Card)DataReference).GibbsFreeEnergy;
        if(AuxUI != null) {
            AuxUI.SetActive(false);
        }
  
    }

    override public void UpdateUI(bool hasPartner)
    {
        // Update Edge UI Element
        Debug.Log("Updating Edge UI");

        LabelText.text = ((Card)DataReference).Label;
        DescriptionText.text = ((Card)DataReference).Description;
        QIDText.text = ((Card)DataReference).QID;
        EnergyConsumedText.text = ((Card)DataReference).EnergyConsumed;
        EnergyProducedText.text = ((Card)DataReference).EnergyProduced;
        GibbsFreeEnergyText.text = ((Card)DataReference).GibbsFreeEnergy;

        if(AuxUI != null) {
            AuxUI.SetActive(true);
            AuxLabelText.text = ((Card)DataReference).AuxLabel;
            AuxDescriptionText.text = ((Card)DataReference).AuxDescription;
            AuxQIDText.text = ((Card)DataReference).AuxQID;
            AuxEnergyConsumedText.text = ((Card)DataReference).AuxEnergyConsumed;
            AuxEnergyProducedText.text = ((Card)DataReference).AuxEnergyProduced;
            AuxGibbsFreeEnergyText.text = ((Card)DataReference).AuxGibbsFreeEnergy;
        }
    }
}
