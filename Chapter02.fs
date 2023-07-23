module Chapter02

    type Tree<'T> =
        | Node of 'T * Tree<'T> * Tree<'T>
        | Leaf
    
    let rec insert value = function
        | Leaf -> Node(value, Leaf, Leaf)
        | Node(v, left, right) as node ->
            if value < v then Node(v, insert value left, right)
            else if value > v then Node(v, left, insert value right)
            else node

    let rec search value = function
        | Leaf -> false
        | Node(v, left, right) ->
            if value < v then search value left
            elif value > v then search value right
            else true

    let sample () =
        let xs = Node(1, Node(0, Leaf, Leaf), Leaf)
        xs

    let add5 sample =
        insert(6)(insert(5)(insert(4)(insert(3)(insert(2)(sample)))))