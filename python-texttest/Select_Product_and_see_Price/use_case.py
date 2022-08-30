from step_definitions import *

story.arrange()

story.act(select_product("Cola", machine))
story.act(wait_5_secs(machine))
story.act(select_product("Chips", machine))
story.act(wait_5_secs(machine))
