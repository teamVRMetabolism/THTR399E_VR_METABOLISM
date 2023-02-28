using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class Experiment : MonoBehaviour
{
    public string filename;
    public string participant;
    public List<GameObject> modelList;
    public List<GameObject> shuffledModelList;
    public List<string> experimentModels;
    public List<string> questionList;
    public List<string> fullQuestionlist;
    public List<string> experimentOrderQuestionAsked;
    public List<int> ratings;

    public GameObject temp;
    public GameObject g;

    public int counter;

    public GameObject changingText;



    public int questionCounter;
    public int modelCounter;



    // Start is called before the first frame update
    void Start()
    {
        participant = menu.input;
        //filename = "C:\\Users\\BARLAB\\Dropbox\\Matt - Farid\\Female_Height_Data" + "/" + "data" + ".csv";
        filename = Application.dataPath + "/" + participant + ".csv";
        questionCounter = 0;
        modelCounter = 0;

        for (int i = 0; i < modelList.Count; i++) {
            foreach (string n in questionList) {
                fullQuestionlist.Add(n);
            }
        }

        foreach(GameObject S in modelList) {
            shuffledModelList.Add(S);
        }

        shuffle();
        counter = (modelList.Count * questionList.Count) - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (questionCounter == (questionList.Count + 1)) {
            DestroyImmediate(temp, true);
            questionCounter = 1;
            g = spawner(modelCounter);
            modelCounter++;
        }

        if (counter < 0) {
            writeToCSV();
            SceneManager.LoadScene("End");
        }
        
    }



    public void shuffle() {
        
        List<GameObject> tempM = shuffledModelList;
        List<GameObject> totalM = new List<GameObject>();
        int maxRange = modelList.Count;

        while(totalM.Count < modelList.Count) {
            int index = Random.Range(0, maxRange);
            totalM.Add(tempM[index]);
            Debug.Log(modelList.Count);
            tempM.RemoveAt(index);
            maxRange--;

        }

        shuffledModelList = totalM;

    }

    private GameObject spawner(int n) { 

        
        temp = Instantiate(shuffledModelList[n]);
        temp.transform.position = new Vector3(12, 0.0f, 1f);
        temp.transform.Rotate(0,180,0);
        
        return temp;

    }


    public void displayFirstModelAndQuestion() {
        if (g == null) {
            g = spawner(modelCounter);
            changingText.GetComponent<Text>().text = fullQuestionlist[counter];
            experimentOrderQuestionAsked.Add(fullQuestionlist[counter]);
            modelCounter++;
            questionCounter++;
            //counter--;
        }
        
    }

    public void displayQuestion() {
        changingText.GetComponent<Text>().text = fullQuestionlist[counter];
        experimentOrderQuestionAsked.Add(fullQuestionlist[counter]);
    }

    
    //write the values from the lists to CSV file
    public void writeToCSV() {
        if (fullQuestionlist.Count > 0) {
            TextWriter tw;
            if (!new FileInfo(filename).Exists) {
                tw = new StreamWriter(filename, false);   //overwrite to make sure empty
                tw.WriteLine("participantID, modelID, questionAsked, rating");
            } else {
                tw = new StreamWriter(filename, true);   //overwrite to make sure empty
            }
        
            tw.Close();

           // tw = new StreamWriter(filename, true);

            for (int i = 0; i < fullQuestionlist.Count; i++) {
                tw = new StreamWriter(filename, true);
                tw.WriteLine(participant + "," + experimentModels[i] + "," + experimentOrderQuestionAsked[i] + "," + ratings[i]);
                tw.Close();
            } 
           // tw.Close();
        }
    }



    public void addRating1() {
        experimentModels.Add(temp.name);
        ratings.Add(1);
        questionCounter++;
        counter--;
        displayQuestion();
    }

    public void addRating2() {
        experimentModels.Add(temp.name);
        ratings.Add(2);
        questionCounter++;
        counter--;
        displayQuestion();
    }

    public void addRating3() {
        experimentModels.Add(temp.name);
        ratings.Add(3);
        questionCounter++;
        counter--;
        displayQuestion();
    }

    public void addRating4() {
        experimentModels.Add(temp.name);
        ratings.Add(4);
        questionCounter++;
        counter--;
        displayQuestion();
    }

    public void addRating5() {
        experimentModels.Add(temp.name);
        ratings.Add(5);
        questionCounter++;
        counter--;
        displayQuestion();
    }

    public void addRating6() {
        experimentModels.Add(temp.name);
        ratings.Add(6);
        questionCounter++;
        counter--;
        displayQuestion();
    }

    public void addRating7() {
        experimentModels.Add(temp.name);
        ratings.Add(7);
        questionCounter++;
        counter--;
        displayQuestion();
    }

   

    
}
