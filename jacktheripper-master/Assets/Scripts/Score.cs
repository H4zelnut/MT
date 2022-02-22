using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    #region BuckRow
    public int bRscore_1;
    public int bRmax_1;
    public int bRscore_2;
    public int bRmax_2;
    public int bRscore_3;
    public int bRmax_3;
    #endregion
    #region HanburryStreet
    public int hBSscore_1;
    public int hBSmax_1;
    public int hBSscore_2;
    public int hBSmax_2;
    public int hBSscore_3;
    public int hBSmax_3;
    #endregion
    #region Dutfields Yard and Mitre Square
    public int dMScore_1;
    public int dMmax_1;
    public int dMScore_2;
    public int dMmax_2;
    #endregion
    #region Millers Court
    public int mCScore_1;
    public int mCMax_1;
    public int mCScore_2;
    public int mCMax_2;
    public int mCScore_3;
    public int mCMax_3;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        bRscore_1 = 0;
        bRmax_1 = 0;
        bRscore_2 = 0;
        bRmax_2 = 0;
        bRscore_3 = 0;
        bRmax_3 = 0;

        hBSscore_1 = 0;
        hBSmax_1 = 0;
        hBSscore_2 = 0;
        hBSmax_2 = 0;
        hBSscore_3 = 0;
        hBSmax_3 = 0;

        dMScore_1 = 0;
        dMmax_1 = 0;
        dMScore_2 = 0;
        dMmax_2 = 0;

        mCScore_1 = 0;
        mCMax_1 = 0;
        mCScore_2 = 0;
        mCMax_2 = 0;
        mCScore_3 = 0;
        mCMax_3 = 0;
    }

}
