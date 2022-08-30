from step_definitions import *

machine.update_bank([25, 10, 5, ])
machine.insert_coin(25)
machine.insert_coin(25)
machine.insert_coin(25)
story.arrange()

story.act(select_product("Candy", machine))
story.act(wait_5_secs(machine))
