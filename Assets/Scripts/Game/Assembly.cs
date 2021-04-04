using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Assembly : MonoBehaviour
{
    public string model { get; set; }
    public double power { get; set; }
    public double price { get; set; }
    public int count { get; set; }
    public bool created { get; set; }

    private Components components;
    private GlobalParam globalParametrs;
    public List<Assembly> auto = new List<Assembly>();

    // Инфо при создании
    public Text powerText, priceText;
    public InputField countInputField, modelInputField;
    public Dropdown engineLevel, bodyLevel, chassisLevel;

    // Инфо при просмотре
    public Text modelTextView, powerTextView, priceTextView, countTextView;
    public Button rightView, leftView;
    private int numberObject;


    private void Awake()
    {
        components = gameObject.GetComponent<Components>();
        globalParametrs = gameObject.GetComponent<GlobalParam>();
    }

    public void createAuto_butt()
    {
        if ((chassisLevel.options.Count != 0) && (bodyLevel.options.Count != 0) && (engineLevel.options.Count != 0))
        {
            if (Convert.ToInt32(countInputField.text) * Convert.ToInt32(priceText.text) <=
                Convert.ToDouble(globalParametrs.money.text))
            {
                Assembly dataObj = new Assembly();
                dataObj.model = modelInputField.text;
                dataObj.power = Convert.ToDouble(powerText.text);
                dataObj.price = Convert.ToDouble(priceText.text);
                dataObj.count = Convert.ToInt32(countInputField.text);
                dataObj.created = false;
                auto.Add(dataObj);


                globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) -
                                              Convert.ToInt32(countInputField.text) * Convert.ToInt32(priceText.text))
                    .ToString();
            }
        }
    }

    /**
         * При изменении компонента
         */
    public void changeDropdown()
    {
        string engineModel = engineLevel.options[engineLevel.value].text;
        string bodyModel = bodyLevel.options[bodyLevel.value].text;
        string chassisModel = chassisLevel.options[chassisLevel.value].text;

        if (engineModel != "" && bodyModel != "" && chassisModel != "")
        {
            Components engine = gameObject.GetComponent<Components>(),
                body = gameObject.GetComponent<Components>(),
                chassis = gameObject.GetComponent<Components>();

            foreach (var obj in components.engine)
            {
                if (obj.model == engineModel)
                    engine = obj;
            }

            foreach (var obj in components.body)
            {
                if (obj.model == bodyModel)
                    body = obj;
            }

            foreach (var obj in components.chassis)
            {
                if (obj.model == chassisModel)
                    chassis = obj;
            }

            powerText.text = ((engine.power + body.power + chassis.power) / 3.00f).ToString();
            priceText.text =
                ((engine.price / engine.count + body.price / body.count + chassis.price / chassis.count) / 2.00f)
                .ToString();
        }
    }

    /**
         * Заполнение Dropdown листа компонентами
         */
    public void componentsForDropdown()
    {
        engineLevel.ClearOptions();
        bodyLevel.ClearOptions();
        chassisLevel.ClearOptions();

        foreach (var obj in components.engine)
        {
            if (obj.created == true)
                engineLevel.options.Add(new Dropdown.OptionData(obj.model));
        }

        foreach (var obj in components.body)
        {
            if (obj.created == true)
                chassisLevel.options.Add(new Dropdown.OptionData(obj.model));
        }

        foreach (var obj in components.chassis)
        {
            if (obj.created == true)
                bodyLevel.options.Add(new Dropdown.OptionData(obj.model));
        }

        if (engineLevel.options.Count != 0)
        {
            engineLevel.value = 0;
            engineLevel.transform.Find("Label").GetComponent<Text>().text = components.engine[0].model;
        }

        if (bodyLevel.options.Count != 0)
        {
            bodyLevel.value = 0;
            bodyLevel.transform.Find("Label").GetComponent<Text>().text = components.body[0].model;
        }

        if (chassisLevel.options.Count != 0)
        {
            chassisLevel.value = 0;
            chassisLevel.transform.Find("Label").GetComponent<Text>().text = components.chassis[0].model;
        }

        if ((chassisLevel.options.Count != 0) && (bodyLevel.options.Count != 0) && (engineLevel.options.Count != 0))
        {
            powerText.text =
                ((components.engine[0].power + components.body[0].power +
                  components.chassis[0].power) / 3.00f).ToString();
            priceText.text =
                ((components.engine[0].price / components.engine[0].count +
                  components.body[0].price / components.body[0].count +
                  components.chassis[0].price / components.chassis[0].count) / 2.00f).ToString();
        }
    }

    public void viewAuto_butt()
    {
        if (auto.Count > 1 && auto[numberObject].created == true)
        {
            leftView.interactable = false;
            rightView.interactable = true;
        }
        else
        {
            leftView.interactable = false;
            rightView.interactable = false;
        }

        numberObject = 0;
        if (auto.Count != 0 && auto[numberObject].created == true)
            viewInfo(auto[numberObject]);
        else
        {
            modelTextView.text = "Нет компонентов";
            powerTextView.text = "";
            priceTextView.text = "";
            countTextView.text = "";
        }
    }

    public void view_butt(bool right = false)
    {
        if (right)
        {
            if ((auto.Count > numberObject + 1) && (auto[numberObject + 1].created == true))
            {
                numberObject++;
                if (leftView.interactable == false)
                    leftView.interactable = true;
            }

            viewInfo(auto[numberObject]);
            if (numberObject == auto.Count - 1)
                rightView.interactable = false;
        }
        else
        {
            if (0 < numberObject)
            {
                numberObject--;
                if (rightView.interactable == false)
                    rightView.interactable = true;
            }

            viewInfo(auto[numberObject]);
            if (numberObject == 0)
                leftView.interactable = false;
        }
    }

    private void viewInfo(Assembly obj)
    {
        modelTextView.text = obj.model;
        powerTextView.text = obj.power.ToString();
        priceTextView.text = (obj.price).ToString();
        countTextView.text = obj.count.ToString();
    }
    
    public void nextSeason()
    {
        foreach (var obj in auto)
        {
            if(obj.created == false)
                obj.created = true;
        }

    }
}