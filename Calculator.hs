 import Control.Applicative ((<$>), (<*>))
type Sign = Double -> Double -> Double
type Data = (String, Sign)
type Register = [Data]
signRegister :: Register
signRegister = [("-", (-)),("+", (+)),("/", (/)),("*", (*))]          
main = print $ count "3 * 2 + 5 - 7 / 2"           
count :: String -> Maybe Double
count = eval signRegister . words          
eval :: Register -> [String] -> Maybe Double
eval [] _ = Nothing 
eval _ [] = Nothing 
eval _ [number] = Just $ read number
eval ((signs, function):rest) unparsed =
    case span (/=signs) unparsed of
        (_, []) -> eval rest unparsed
        (before, after) -> 
            function
                <$> (eval signRegister before)
                <*> (eval signRegister $ drop 1 after)
