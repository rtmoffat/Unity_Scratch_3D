using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Text.RegularExpressions;

public class tic_tac_toe_controller : MonoBehaviour
{
    public GameObject player_o_Obj;
    public GameObject player_x_Obj;
    public GameObject result_canvas;
    public int turn = 1; //1=x,2=o
    private char ci = 'N';
    private char[,] board_state = new char[3, 3] { { 'a', 'b', 'c' }, { 'd', 'e','f' }, { 'g','h','i' } };


    private void Start()
    {
        //boardstate spaces are initially set to null by default.
        //1 = X
        //2 = O
        /*board_state[0, 0] = 'X';
        board_state[0, 1] = 'Y';
        board_state[1,1] = 'Z';
        board_state[1, 2] = 'Q';
        board_state[2, 2] = 'w';*/
        Debug.Log("Starting "+board_state[0,0]);
        //board_state[1][1].Add("X");
    }
    private void CheckWinState()
    {
        Debug.Log("Checking win state");
        Debug.Log(board_state[0, 0] + " " + board_state[1, 0] + " " + board_state[2, 0] + " ");
        for (int row=0;row<=2;row+=1)
        {
            if ((board_state[row, 0] == board_state[row, 1]) && (board_state[row, 2] == board_state[row, 1]))
            {
                Debug.Log("won row!");
                result_canvas.SetActive(true);
            }
        }
        for (int col = 0; col <= 2; col += 1)
        {
            if ((board_state[0, col] == board_state[1, col]) && (board_state[2, col] == board_state[1, col]))
            {
                Debug.Log("won column!!");
                result_canvas.SetActive(true);
            }
        }
        /*char cur_val = 'Y';
        int cnt = 0;
        //Check each row
        for (int i=0;i<2;i+=1)
        {
            if (board_state[0,i] == cur_val) {
                cnt++;
                continue;
            }
            else
            {
                cnt = 0;
                cur_val = board_state[0,i];
            }
            if (cnt==3)
            {
                Debug.Log("won!!");
                break;
            }
        }*/

        //Win states
        //Rows
        //1,1;1,2;1,3
        //2,1;2,2;2,3
        //3,1;3,2;3,3
        //Columns
        //1,1;2,1,3,1
        //1,2;2,2;3,2
        //1,3;2,3;3,3
        //Diag 1,1;3,3
        //1,1;2,2;3,3
        //Diag 1,3;3,1
        //1,3;2,2;3,1
    }
    public void OnPlaceToken(InputValue inputValue)
    {
        string pattern_row = "([0-2]),";
        string pattern_col = ",([0-2])";
        Debug.Log("hi "+inputValue.ToString());
        Vector2 mousePos=Mouse.current.position.ReadValue();
        
        Vector3 objLoc = new Vector3(mousePos.x, mousePos.y, 1.0f);
        Vector3 newLoc = Camera.main.ScreenToWorldPoint(objLoc);
        Ray ray = Camera.main.ScreenPointToRay(objLoc);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            if ((hit.collider != null) && (hit.collider.name.Contains("Cube")))
            {
                Debug.Log("hit " + hit.collider.name);
                newLoc = Camera.main.ScreenToViewportPoint(hit.collider.gameObject.transform.position);
                newLoc.z = -2;
                if (turn == 1)
                {
                    Instantiate(player_x_Obj, Camera.main.ViewportToScreenPoint(newLoc), player_x_Obj.transform.rotation);
                    
                    string r = Regex.Match(hit.collider.name, pattern_row).Groups[1].Value;
                    string c = Regex.Match(hit.collider.name, pattern_col).Groups[1].Value;
                    Debug.Log("Result=" + r + " " + c);
                    board_state[int.Parse(r),int.Parse(c)]='X';
                    //int c = int.Parse(Regex.Match(hit.collider.name, pattern_col).Value);
                    turn = 2;
                }
                else
                {
                    Instantiate(player_o_Obj, Camera.main.ViewportToScreenPoint(newLoc), player_o_Obj.transform.rotation);
                    string r = Regex.Match(hit.collider.name, pattern_row).Groups[1].Value;
                    string c = Regex.Match(hit.collider.name, pattern_col).Groups[1].Value;
                    Debug.Log("Result=" + r + " " + c);
                    board_state[int.Parse(r), int.Parse(c)] = 'O';
                    turn = 1;
                }
                CheckWinState();
            }
        }
    }
}
