from step_definitions import *

machine.insert_coin(25)
machine.insert_coin(10)
story.arrange()

story.act(return_coins(machine))

