﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NotReaper.Models;
using NotReaper.Targets;
using NotReaper.UserInput;
using UnityEngine;

namespace NotReaper.Grid {


    public class HoverTarget : MonoBehaviour {

        public GameObject icon;
        private bool iconEnabled = true;
        public GameObject cursor;
        public SpriteRenderer cursorTint;
        public GameObject standard;
        public GameObject hold;
        public GameObject horizontal;
        public GameObject vertical;
        public GameObject chainStart;
        public GameObject chainNode;
        public GameObject melee;


        public void TryEnable() {
            iconEnabled = true;
            icon.SetActive(true);
        }
        public void TryDisable() {

            switch (EditorInput.selectedTool) {
                case EditorTool.ChainBuilder:
                case EditorTool.DragSelect:
                    break;

                default:
                    iconEnabled = false;
                    icon.SetActive(false);
                    break;
            }



        }

        Vector3 lastPos = new Vector3();
        private void Update() {
            
            if (!iconEnabled) return;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            switch (EditorInput.selectedTool) {
                case EditorTool.ChainBuilder:
                case EditorTool.DragSelect:

                    transform.position = new Vector3(mousePos.x, mousePos.y, -1f);

                    break;

                default:
                    Vector3 newPos = NoteGridSnap.SnapToGrid(new Vector3(mousePos.x, mousePos.y, -1f), EditorInput.selectedSnappingMode);
                    //if (newPos == lastPos) {
                        //return;
                    //}
                    //lastPos = newPos;
                    transform.position = newPos;
                    //transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, 0.3f);
                    break;
            }





        }

        IEnumerator AnimateHandChange(SpriteRenderer sr, Color color) {

            sr.DOColor(color, 0.3f);


            yield break;
        }



        public float animColorSpeed = 0.3f;
        public void UpdateUIHandColor(Color color) {
            standard.GetComponent<SpriteRenderer>().DOColor(color, animColorSpeed);
            hold.GetComponent<SpriteRenderer>().DOColor(color, animColorSpeed);
            horizontal.GetComponent<SpriteRenderer>().DOColor(color, animColorSpeed);
            vertical.GetComponent<SpriteRenderer>().DOColor(color, animColorSpeed);
            chainStart.GetComponent<SpriteRenderer>().DOColor(color, animColorSpeed);
            chainNode.GetComponent<SpriteRenderer>().DOColor(color, animColorSpeed);
            melee.GetComponent<SpriteRenderer>().DOColor(color, animColorSpeed);
            cursorTint.DOColor(color, animColorSpeed);
        }

        public void UpdateUITool(EditorTool tool) {

            if (tool == EditorTool.DragSelect || tool == EditorTool.ChainBuilder) {
                cursor.SetActive(true);
            } else {
                cursor.SetActive(false);
            }

            standard.SetActive(tool == EditorTool.Standard);
            hold.SetActive(tool == EditorTool.Hold);
            horizontal.SetActive(tool == EditorTool.Horizontal);
            vertical.SetActive(tool == EditorTool.Vertical);
            chainStart.SetActive(tool == EditorTool.ChainStart);
            chainNode.SetActive(tool == EditorTool.ChainNode);
            melee.SetActive(tool == EditorTool.Melee);
        }


    }

}