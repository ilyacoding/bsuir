library ieee;
use ieee.std_logic_1164.all;

entity d_enable_latch_tb is
end d_enable_latch_tb;

architecture TB_ARCHITECTURE of d_enable_latch_tb is
	component d_enable_latch
	port(
		D : in std_logic;
		E : in std_logic;
		Q : out std_logic;
		nQ : out std_logic );
	end component;


	signal D : std_logic := '0';
	signal E : std_logic := '0';

	signal Q_struct : std_logic;
	signal nQ_struct : std_logic;	 
	
	signal Q_beh : std_logic;
	signal nQ_beh : std_logic;
	
	signal Q_param : std_logic;
	signal nQ_param : std_logic;   
	
	constant data_clock_period : time := 10 ns;
	constant enabled_period : time := 10 ns;
	constant disabled_period : time := enabled_period * 4;
begin
	struct: entity d_enable_latch(struct)
		port map (
			D => D,
			E => E,
			Q => Q_struct,
			nQ => nQ_struct
		);	 
		
	beh : entity d_enable_latch(beh)
	port map (
		D => D,
		E => E,
		Q => Q_beh,
		nQ => nQ_beh
	);
	
	param : entity d_enable_latch(param)
	port map (
		D => D,
		E => E,
		Q => Q_param,
		nQ => nQ_param
	);
	
	D <= not D after data_clock_period;
	E <= '1' after disabled_period when E = '0' else '0' after enabled_period;	

end TB_ARCHITECTURE;


