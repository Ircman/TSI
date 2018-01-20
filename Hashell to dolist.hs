addTodo :: (Int, String) -> IO ()
addTodo (n, todo) = putStrLn (show n ++ ": " ++ todo)

task :: [String] -> IO ()
task todolist = do
    putStrLn ""
    putStrLn "Текущий список задач"
    mapM_ addTodo (zip [0..] todolist)
    command <- getLine
    readcomand command todolist

readcomand :: String -> [String] -> IO ()
readcomand ('+':' ':todo) todolist = task (todo:todolist)
readcomand ('-':' ':num ) todolist =
    case delete (read num) todolist of
        Nothing -> do
            putStrLn "Такова порядкового номера нету  "
            task todolist
        Just todolist' -> task todolist'
readcomand  command       todolist = do
    putStrLn ("Неверная команда: `" ++ command ++ "`")
    task todolist
    
delete :: Int -> [a] -> Maybe [a]
delete 0 (_:as) = Just as
delete n (a:as) = do
    let n' = n - 1
    as' <- n' `seq` delete n' as
    return (a:as')
delete _  []    = Nothing

main = do
    putStrLn "Команды:"
    putStrLn "+ <String> - довавить элемент"
    putStrLn "- <Int>    - удалить элемент (порядковый номер)"
    task []
