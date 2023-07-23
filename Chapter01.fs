module Chapter01

    /// Write a function `suffixes` of type (list -> [list]) that takes a
    /// list `xs` and returns a list of all the suffixes of `xs` in
    /// decreasing order of length.

    ///Show that the resulting list of suffixes can be generated in O(n)
    /// time and represented in O(n) space.
    /// 
    /// e.g. - suffixes [1; 2; 3; 4] = [[1; 2; 3; 4]; [2; 3; 4]; [3; 4]; [4]; []]
    let suffixes xs =
        let rec loop xs ys =
            match xs with
            | []      -> ys
            | x :: xs -> loop xs (xs :: ys)
        loop xs [xs]
        |> List.rev
