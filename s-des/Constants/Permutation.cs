namespace s_des.Constants;

public static class Permutation
{
    public static int[] P10 { get; } = {3, 5, 2, 7, 4, 10, 1, 9, 8, 6};
    public static int[] P8 { get; } = {6, 3, 7, 4, 8, 5, 10, 9};
    public static int[] P4 { get; } = {2, 4, 3, 1};

    public static int[] IP { get; } = {2, 6, 3, 1, 4, 8, 5, 7};
    public static int[] IP_1 { get; } = {4, 1, 3, 5, 7, 2, 8, 6};
    public static int[] EP { get; } = {4, 1, 2, 3, 2, 3, 4, 1};
}