library ieee;
use ieee.std_logic_1164.all;

entity LFSR_Out_tb is
	generic (N : integer := 4);
end LFSR_Out_tb;

architecture Beh of LFSR_Out_tb is			 
	component LFSR_Out		   
		generic (N : integer := 4);
		port(
			CLK: in std_logic;
			RST: in std_logic;		
			State: out std_logic_vector(0 to N-1);
			Pout: out std_logic
			);
	end component;
	signal CLK: std_logic := '0';
	signal RST: std_logic := '0';	
	
	signal State: std_logic_vector(0 to N-1);
	signal Pout: std_logic;
	constant clock_period: time := 10 ns;
begin
	uut: LFSR_Out port map (
		CLK => CLK,
		RST => RST,		
		POut => POut,
		State => State
		);
	
	CLK <= not CLK after clock_period;
end Beh;