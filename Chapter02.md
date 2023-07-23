# Chapter 02 - Binary Search Trees

## Before You Begin

There were points in the book we didn't implement as we're still finding
footing in F#.  We will complete them here.


## Todos
Make certain to setup a Benchmark Runner to measure function performance.
Add your classes/modules as Benchmarks.

```
signature SET =
sig
  type Elem
  type Set

  val empty    : Set
  val insert   : Elem x Set -> Set
  val member   : Elem x Set -> Bool
end

signature ORDERED =
  (* a totally ordered type and its comparison functions *)
sig
  type T

  val eq  : T x T -> bool
  val lt  : T x T -> bool
  var leq : T x T -> bool
end

functor UnbalancedSet(Element: ORDERED): SET =
struct
  type Elem = Element.T
  datatype Tree = E | T of Tree x Elem x Tree
  type Set = Tree

  val empty = E

  fun member (x, E) = false
    | member (x, T (a, y, b)) =
        if Element.lt (x, y) then T (insert (x, a), y, b)
        else if Element.lt (y, x) then T (a, y, insert (x, b))
        else true
  
  fun insert (x, E) = T (E, x, E)
    | insert (x, s as T (a, y, b)) =
        if Element.lt (x, y) then T (insert (x, a), y, b)
        else if Element.lt (y, x) then T (a, y, insert(x, b))
        else s
```

**WARNING - DO NOT RUN (BENCHMARKS) ON OUTER-HEAVEN. IT WILL CRASH!**

### Steps to setup Benchmark Runner

``` 
cd <path_to>/purely-functional-data-structures
dotnet run -c Release
```


## Exercises

- Exercise 02.2
  - In the worst case, `search` performs approximately `2d` comparisons,
    where `d` is the depth of the tree.  Rewrite `search` to take no more
    than `d + 1` comparisons by keeping track of a candidate element that
    *might* be equal to the query element (say, the last element for which)
    lt returned false or leq returned true) and checking for equality only
    when you reach the bottom of the tree.
- Exercise 02.3
  - Inserting an existing element into a binary search tree copies the
    entire search path even though the copied notes are indistinguishable
    from the originals. Rewrite `insert` using exceptions to avoid this
    copying. Establish only one handler per insertion rather than one
    handler per insertion.
- Exercise 02.4
  - Combine the ideas of the previous two exercises to obtain a version of
    `insert` that performs no unnecessary copying and uses no more than
    `d + 1` comparisons
- Exercise 02.5
  - Sharing can also be useful within a single object, not just between
    objects. For example, if the two subtrees of a given node are identical,
    then they can be represented by the same tree.
    - Using this idea, write a function `complete` of type __Elem x int -> Tree__
      where `complete(x, d)` creates a complete binary tree of depth `d`
      with `x` stored in every node. _(Of course, this function makes no sense
      for the set abstraction, but it can be useful as an auxiliary function
      for other abstractions, such as bags)_ This function should run in `O(d)` time.
    - Extend this function to create balanced trees of arbitrary size. These
      trees will not always be complete binary trees, but should be as balanced
      as possible: for any given node, the two subtrees should differ in size by
      at most one. This function should run in `O(log n)` time. _(Hint: use a
      helper function `create2` that, given a size `m`, creates a pair of trees,
      one of size `m` and one of size `m+1`.)
- Exercise 02.6
  - Adapt the `UnbalancedSet` functor to support finite maps rather than sets.