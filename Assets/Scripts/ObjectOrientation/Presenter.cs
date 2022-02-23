using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    TodoPresenter todoPresenter = new TodoPresenter();

    void Start()
    {
        Debug.Log(todoPresenter.todo);
    }
}
