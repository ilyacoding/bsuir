SetActiveLib -work
comp -include "$dsn\src\task 1\bistable_element.vhd" 
comp -include "$dsn\src\task 1\test-bench\bistable_element_TB.vhd" 
asim +access +r bistableelement_TB

wave 

wave -noreg initialized_Q
wave -noreg initialized_nQ
wave -noreg uninitizlied_nQ
wave -noreg uninitialized_Q

# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\bistableelement_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_bistableelement 	 
run 1us
