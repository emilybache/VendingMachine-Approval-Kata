from step_definitions import *

machine.insert_coin(25)
machine.insert_coin(25)
machine.insert_coin(10)
machine.insert_coin(5)
story.arrange()

story.act(select_product("Candy", machine))
story.act(wait_5_secs(machine))
