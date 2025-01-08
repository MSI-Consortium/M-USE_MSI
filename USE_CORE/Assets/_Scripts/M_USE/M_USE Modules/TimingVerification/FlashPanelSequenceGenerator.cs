using System;

public class FlashPanelSequenceGenerator
{
    public int panelStatus;
    public int sequenceIndex;
    public int sequenceLength;
    private int[] currentSequence;
    private int lastNumberOfFlipPairs;

    private static Random random = new Random();

    public void PanelSequence()
    {
        lastNumberOfFlipPairs = -1; // Initialize to an impossible value to ensure it changes on first run
        GenerateNewSequence();
        sequenceIndex = 0;
        panelStatus = currentSequence[sequenceIndex];
    }

    public void GenerateNewSequence()
    {
        int numberOfFlipPairs;
        do
        {
            numberOfFlipPairs = random.Next(12, 25); // Generates a random value between 12 and 24 (inclusive)
        } while (numberOfFlipPairs == lastNumberOfFlipPairs);

        lastNumberOfFlipPairs = numberOfFlipPairs;

        int[] fixedSequence = { 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1 };

        int[] flipPairSequence = new int[numberOfFlipPairs * 2];
        for (int i = 0; i < numberOfFlipPairs * 2; i += 2)
        {
            flipPairSequence[i] = 0;
            flipPairSequence[i + 1] = 1;
        }

        currentSequence = new int[fixedSequence.Length + flipPairSequence.Length];
        Array.Copy(fixedSequence, 0, currentSequence, 0, fixedSequence.Length);
        Array.Copy(flipPairSequence, 0, currentSequence, fixedSequence.Length, flipPairSequence.Length);

        sequenceLength = currentSequence.Length;
    }

    public void UpdateSequence()
    {
        if (sequenceIndex < sequenceLength - 1)
        {
            sequenceIndex += 1;
        }
        else
        {
            sequenceIndex = 0;
            GenerateNewSequence();
        }
        panelStatus = currentSequence[sequenceIndex];
    }

    // Optional: A method to get the current sequence for testing purposes
    public int[] GetCurrentSequence()
    {
        return currentSequence;
    }
}