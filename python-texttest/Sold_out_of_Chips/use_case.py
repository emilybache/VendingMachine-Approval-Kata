from step_definitions import *

machine.insert_coin(25)
machine.insert_coin(25)
machine.update_stock("Chips", 0)
story.arrange()

story.act(select_product("Chips", machine))
story.act(wait_5_secs(machine))
