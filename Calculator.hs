import Control.Applicative ((<$>), (<*>))
type Sign = Double -> Double -> Double
type Data = (String, Sign)
type Register = [Data]
operatorRegister :: Register
operatorRegister = [("-", (-)),("+", (+)),("/", (/)),("*", (*))]          
main = print $ count "3 * 2 + 5 - 7 / 2"           
count :: String -> Maybe Double
count = eval operatorRegister . words          
eval :: Register -> [String] -> Maybe Double
eval [] _ = Nothing 
eval _ [] = Nothing 
eval _ [number] = Just $ read number
eval ((operator, function):rest) unparsed =
    case span (/=operator) unparsed of
        (_, []) -> eval rest unparsed
        (beforeOperator, afterOperator) -> 
            function
                <$> (eval operatorRegister beforeOperator)
                <*> (eval operatorRegister $ drop 1 afterOperator)