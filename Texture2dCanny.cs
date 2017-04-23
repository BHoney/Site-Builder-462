using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture2dCanny : MonoBehaviour {

	public Texture2D theTexture;
	public int[,] binaryPixels;
    public float threshHold;
	private Color [,] pixels;
	private Color [] pixelArray;
	private int width;
	private int height;


	// Use this for initialization
	void Start () {

		width = theTexture.width;
		height = theTexture.height;

		//get the pixels of the Texture/floorplan
		pixelArray = theTexture.GetPixels();

		//change to 2d array
		pixels = singleArrayToDouble (pixelArray);

      //  pixels = CannyEdgeDetection(pixels, threshHold );

		//change into integer 2d array
		binaryPixels = ColorArrayToBinaryIntArray (pixels);

		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {

				Debug.Log(binaryPixels[j,i]);
			
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//turns a flattened Color array into a 2D Color Array
	public Color[,] singleArrayToDouble( Color[] flattenedPixelArray){

		Color[,] pixels = new Color[width, height];

		for (int y = 0; y < height; y++) {
		
			for (int x = 0; x < width; x++) {
			
				pixels [x, y] = flattenedPixelArray [x * width + y];
			
			}
		}
			
		return pixels;

	}

	//2d Colors Array to a Binary int 2d array
	public int[,] ColorArrayToBinaryIntArray( Color[,] pixels){
		
		int[,] binaryPixels = new int[width,height];

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				if (pixels [x, y] == Color.white) {
					binaryPixels [x,y] = 0;
				} else {
					binaryPixels [x, y] = 1;
				}
			}
		}
	
		return binaryPixels;
	
	}

    private Color[,] CannyEdgeDetection(Color[,] image, float threshHold) {

        Color[,] n = new Color[width,height];

        float[,] allPixR = new float[width, height];
        float[,] allPixG = new float[width, height];
        float[,] allPixB = new float[width, height];

        for (int x = 0; x < width; x++) {

            for (int y = 0; y < height; y++) {

                allPixR[x, y] = image[x, y].r;
                allPixG[x, y] = image[x, y].g;
                allPixB[x, y] = image[x, y].b;

            }

        }

        for (int i = 2; i < width - 2; i++) {

            for (int j = 2; j < height - 2; j++) {

                float red = (
                             ((allPixR[i - 2, j - 2]) * 1 + (allPixR[i - 1, j - 2]) * 4 + (allPixR[i, j - 2]) * 7 + (allPixR[i + 1, j - 2]) * 4 + (allPixR[i + 2, j - 2])
                             + (allPixR[i - 2, j - 1]) * 4 + (allPixR[i - 1, j - 1]) * 16 + (allPixR[i, j - 1]) * 26 + (allPixR[i + 1, j - 1]) * 16 + (allPixR[i + 2, j - 1]) * 4
                             + (allPixR[i - 2, j]) * 7 + (allPixR[i - 1, j]) * 26 + (allPixR[i, j]) * 41 + (allPixR[i + 1, j]) * 26 + (allPixR[i + 2, j]) * 7
                             + (allPixR[i - 2, j + 1]) * 4 + (allPixR[i - 1, j + 1]) * 16 + (allPixR[i, j + 1]) * 26 + (allPixR[i + 1, j + 1]) * 16 + (allPixR[i + 2, j + 1]) * 4
                             + (allPixR[i - 2, j + 2]) * 1 + (allPixR[i - 1, j + 2]) * 4 + (allPixR[i, j + 2]) * 7 + (allPixR[i + 1, j + 2]) * 4 + (allPixR[i + 2, j + 2]) * 1) / 273
                             );

                float green = (
                              ((allPixG[i - 2, j - 2]) * 1 + (allPixG[i - 1, j - 2]) * 4 + (allPixG[i, j - 2]) * 7 + (allPixG[i + 1, j - 2]) * 4 + (allPixG[i + 2, j - 2])
                              + (allPixG[i - 2, j - 1]) * 4 + (allPixG[i - 1, j - 1]) * 16 + (allPixG[i, j - 1]) * 26 + (allPixG[i + 1, j - 1]) * 16 + (allPixG[i + 2, j - 1]) * 4
                              + (allPixG[i - 2, j]) * 7 + (allPixG[i - 1, j]) * 26 + (allPixG[i, j]) * 41 + (allPixG[i + 1, j]) * 26 + (allPixG[i + 2, j]) * 7
                              + (allPixG[i - 2, j + 1]) * 4 + (allPixG[i - 1, j + 1]) * 16 + (allPixG[i, j + 1]) * 26 + (allPixG[i + 1, j + 1]) * 16 + (allPixG[i + 2, j + 1]) * 4
                              + (allPixG[i - 2, j + 2]) * 1 + (allPixG[i - 1, j + 2]) * 4 + (allPixG[i, j + 2]) * 7 + (allPixG[i + 1, j + 2]) * 4 + (allPixG[i + 2, j + 2]) * 1) / 273
                              );

                float blue = (
                              ((allPixB[i - 2, j - 2]) * 1 + (allPixB[i - 1, j - 2]) * 4 + (allPixB[i, j - 2]) * 7 + (allPixB[i + 1, j - 2]) * 4 + (allPixB[i + 2, j - 2])
                              + (allPixB[i - 2, j - 1]) * 4 + (allPixB[i - 1, j - 1]) * 16 + (allPixB[i, j - 1]) * 26 + (allPixB[i + 1, j - 1]) * 16 + (allPixB[i + 2, j - 1]) * 4
                              + (allPixB[i - 2, j]) * 7 + (allPixB[i - 1, j]) * 26 + (allPixB[i, j]) * 41 + (allPixB[i + 1, j]) * 26 + (allPixB[i + 2, j]) * 7
                              + (allPixB[i - 2, j + 1]) * 4 + (allPixB[i - 1, j + 1]) * 16 + (allPixB[i, j + 1]) * 26 + (allPixB[i + 1, j + 1]) * 16 + (allPixB[i + 2, j + 1]) * 4
                              + (allPixB[i - 2, j + 2]) * 1 + (allPixB[i - 1, j + 2]) * 4 + (allPixB[i, j + 2]) * 7 + (allPixB[i + 1, j + 2]) * 4 + (allPixB[i + 2, j + 2]) * 1) / 273
                              );
                n[i, j] = new Color(red, green, blue);
            }
        }

        float[,] allPixRn = new float[width, height];
        float[,] allPixGn = new float[width, height];
        float[,] allPixBn = new float[width, height];

        for (int i = 0; i < width; i++) {

            for (int j = 0; j < height; j++) {

                allPixRn[i,j] = n[i, j].r;
                allPixGn[i, j] = n[i, j].g;
                allPixBn[i, j] = n[i, j].b;

            }

        }

        int[,] gx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        int[,] gy = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
        float new_rx, new_ry;
        float new_gx, new_gy;
        float new_bx, new_by;
        float rc, gc, bc;
        float gradR, gradG, gradB;

        float[,] graidientR = new float[width, height];
        float[,] graidientG = new float[width, height];
        float[,] graidientB = new float[width, height];

        int atanR, atanG, atanB;

        int[,] tanR = new int[width, height];
        int[,] tanG = new int[width, height];
        int[,] tanB = new int[width, height];

        for (int i = 1; i < width - 1; i++)
        {
            for (int j = 1; j < height - 1; j++)
            {

                new_rx = 0;
                new_ry = 0;
                new_gx = 0;
                new_gy = 0;
                new_bx = 0;
                new_by = 0;

                for (int wi = -1; wi < 2; wi++)
                {
                    for (int hw = -1; hw < 2; hw++)
                    {
                        rc = allPixRn[i + hw, j +  wi];
                        new_rx += gx[wi + 1, hw + 1] * rc;
                        new_ry += gy[wi + 1, hw + 1] * rc;

                        gc = allPixGn[i + hw, j + wi];
                        new_gx += gx[wi + 1, hw + 1] * gc;
                        new_gy += gy[wi + 1, hw + 1] * gc;

                        bc = allPixBn[i + hw, j + wi];
                        new_bx += gx[wi + 1, hw + 1] * bc;
                        new_by += gy[wi + 1, hw + 1] * bc;
                    }
                }

                //find gradieant
                gradR = Mathf.Sqrt((new_rx * new_rx) + (new_ry * new_ry));
                graidientR[i, j] = gradR;

                gradG = Mathf.Sqrt((new_gx * new_gx) + (new_gy * new_gy));
                graidientG[i, j] = gradG;

                gradB = Mathf.Sqrt((new_bx * new_gx) + (new_by * new_by));
                graidientB[i, j] = gradB;
                //
                //find tans
                ////////////////tan red//////////////////////////////////
                atanR = (int)((Mathf.Atan(new_ry / new_rx)) * (180 / Mathf.PI));
                if ((atanR > 0 && atanR < 22.5) || (atanR > 157.5 && atanR < 180))
                {
                    atanR = 0;
                }
                else if (atanR > 22.5 && atanR < 67.5)
                {
                    atanR = 45;
                }
                else if (atanR > 67.5 && atanR < 112.5)
                {
                    atanR = 90;
                }
                else if (atanR > 112.5 && atanR < 157.5)
                {
                    atanR = 135;
                }

                if (atanR == 0)
                {
                    tanR[i, j] = 0;
                }
                else if (atanR == 45)
                {
                    tanR[i, j] = 1;
                }
                else if (atanR == 90)
                {
                    tanR[i, j] = 2;
                }
                else if (atanR == 135)
                {
                    tanR[i, j] = 3;
                }
                ////////////////tan red end//////////////////////////////////

                ////////////////tan green//////////////////////////////////
                atanG = (int)((Mathf.Atan(new_gy / new_gx)) * (180 / Mathf.PI));
                if ((atanG > 0 && atanG < 22.5) || (atanG > 157.5 && atanG < 180))
                {
                    atanG = 0;
                }
                else if (atanG > 22.5 && atanG < 67.5)
                {
                    atanG = 45;
                }
                else if (atanG > 67.5 && atanG < 112.5)
                {
                    atanG = 90;
                }
                else if (atanG > 112.5 && atanG < 157.5)
                {
                    atanG = 135;
                }


                if (atanG == 0)
                {
                    tanG[i, j] = 0;
                }
                else if (atanG == 45)
                {
                    tanG[i, j] = 1;
                }
                else if (atanG == 90)
                {
                    tanG[i, j] = 2;
                }
                else if (atanG == 135)
                {
                    tanG[i, j] = 3;
                }
                ////////////////tan green end//////////////////////////////////


                ////////////////tan blue//////////////////////////////////
                atanB = (int)((Mathf.Atan(new_by / new_bx)) * (180 / Mathf.PI));
                if ((atanB > 0 && atanB < 22.5) || (atanB > 157.5 && atanB < 180))
                {
                    atanB = 0;
                }
                else if (atanB > 22.5 && atanB < 67.5)
                {
                    atanB = 45;
                }
                else if (atanB > 67.5 && atanB < 112.5)
                {
                    atanB = 90;
                }
                else if (atanB > 112.5 && atanB < 157.5)
                {
                    atanB = 135;
                }

                if (atanB == 0)
                {
                    tanB[i, j] = 0;
                }
                else if (atanB == 45)
                {
                    tanB[i, j] = 1;
                }
                else if (atanB == 90)
                {
                    tanB[i, j] = 2;
                }
                else if (atanB == 135)
                {
                    tanB[i, j] = 3;
                }
                ////////////////tan blue end//////////////////////////////////
            }
        }

        float[,] allPixRs = new float[width, height];
        float[,] allPixGs = new float[width, height];
        float[,] allPixBs = new float[width, height];

        for (int i = 2; i < width - 2; i++)
        {
            for (int j = 2; j < height - 2; j++)
            {

                ////red
                if (tanR[i, j] == 0)
                {
                    if (graidientR[i - 1, j] < graidientR[i, j] && graidientR[i + 1, j] < graidientR[i, j])
                    {
                        allPixRs[i, j] = graidientR[i, j];
                    }
                    else
                    {
                        allPixRs[i, j] = 0;
                    }
                }
                if (tanR[i, j] == 1)
                {
                    if (graidientR[i - 1, j + 1] < graidientR[i, j] && graidientR[i + 1, j - 1] < graidientR[i, j])
                    {
                        allPixRs[i, j] = graidientR[i, j];
                    }
                    else
                    {
                        allPixRs[i, j] = 0;
                    }
                }
                if (tanR[i, j] == 2)
                {
                    if (graidientR[i, j - 1] < graidientR[i, j] && graidientR[i, j + 1] < graidientR[i, j])
                    {
                        allPixRs[i, j] = graidientR[i, j];
                    }
                    else
                    {
                        allPixRs[i, j] = 0;
                    }
                }
                if (tanR[i, j] == 3)
                {
                    if (graidientR[i - 1, j - 1] < graidientR[i, j] && graidientR[i + 1, j + 1] < graidientR[i, j])
                    {
                        allPixRs[i, j] = graidientR[i, j];
                    }
                    else
                    {
                        allPixRs[i, j] = 0;
                    }
                }

                //green
                if (tanG[i, j] == 0)
                {
                    if (graidientG[i - 1, j] < graidientG[i, j] && graidientG[i + 1, j] < graidientG[i, j])
                    {
                        allPixGs[i, j] = graidientG[i, j];
                    }
                    else
                    {
                        allPixGs[i, j] = 0;
                    }
                }
                if (tanG[i, j] == 1)
                {
                    if (graidientG[i - 1, j + 1] < graidientG[i, j] && graidientG[i + 1, j - 1] < graidientG[i, j])
                    {
                        allPixGs[i, j] = graidientG[i, j];
                    }
                    else
                    {
                        allPixGs[i, j] = 0;
                    }
                }
                if (tanG[i, j] == 2)
                {
                    if (graidientG[i, j - 1] < graidientG[i, j] && graidientG[i, j + 1] < graidientG[i, j])
                    {
                        allPixGs[i, j] = graidientG[i, j];
                    }
                    else
                    {
                        allPixGs[i, j] = 0;
                    }
                }
                if (tanG[i, j] == 3)
                {
                    if (graidientG[i - 1, j - 1] < graidientG[i, j] && graidientG[i + 1, j + 1] < graidientG[i, j])
                    {
                        allPixGs[i, j] = graidientG[i, j];
                    }
                    else
                    {
                        allPixGs[i, j] = 0;
                    }
                }

                //blue
                if (tanB[i, j] == 0)
                {
                    if (graidientB[i - 1, j] < graidientB[i, j] && graidientB[i + 1, j] < graidientB[i, j])
                    {
                        allPixBs[i, j] = graidientB[i, j];
                    }
                    else
                    {
                        allPixBs[i, j] = 0;
                    }
                }
                if (tanB[i, j] == 1)
                {
                    if (graidientB[i - 1, j + 1] < graidientB[i, j] && graidientB[i + 1, j - 1] < graidientB[i, j])
                    {
                        allPixBs[i, j] = graidientB[i, j];
                    }
                    else
                    {
                        allPixBs[i, j] = 0;
                    }
                }
                if (tanB[i, j] == 2)
                {
                    if (graidientB[i, j - 1] < graidientB[i, j] && graidientB[i, j + 1] < graidientB[i, j])
                    {
                        allPixBs[i, j] = graidientB[i, j];
                    }
                    else
                    {
                        allPixBs[i, j] = 0;
                    }
                }
                if (tanB[i, j] == 3)
                {
                    if (graidientB[i - 1, j - 1] < graidientB[i, j] && graidientB[i + 1, j + 1] < graidientB[i, j])
                    {
                        allPixBs[i, j] = graidientB[i, j];
                    }
                    else
                    {
                        allPixBs[i, j] = 0;
                    }
                }
            }
        }
        int[,] allPixRf = new int[width, height];
        int[,] allPixGf = new int[width, height];
        int[,] allPixBf = new int[width, height];
        Color[,] edgeDetectedImage = new Color[width,height];

        for (int i = 2; i < width - 2; i++)
        {
            for (int j = 2; j < height - 2; j++)
            {
                if (allPixRs[i, j] > threshHold)
                {
                    allPixRf[i, j] = 1;
                }
                else
                {
                    allPixRf[i, j] = 0;
                }

                if (allPixGs[i, j] > threshHold)
                {
                    allPixGf[i, j] = 1;
                }
                else
                {
                    allPixGf[i, j] = 0;
                }

                if (allPixBs[i, j] > threshHold)
                {
                    allPixBf[i, j] = 1;
                }
                else
                {
                    allPixBf[i, j] = 0;
                }



                if (allPixRf[i, j] == 1 || allPixGf[i, j] == 1 || allPixBf[i, j] == 1)
                {
                    edgeDetectedImage[i,j] = Color.black;
                }
                else
                    edgeDetectedImage[i,j] = Color.white;
            }
        }


        return edgeDetectedImage;

    }

}
