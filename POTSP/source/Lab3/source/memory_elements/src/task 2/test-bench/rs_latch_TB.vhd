library ieee;
use ieee.std_logic_1164.all;

entity rs_latch_tb is
end rs_latch_tb;

architecture TB_ARCHITECTURE of rs_latch_tb is
	component RS_Latch
		port(
			R : in std_logic;
			S : in std_logic;
			Q : out std_logic;
			nQ : out std_logic 
			);
	end component;
	
	signal R : std_logic;
	signal S : std_logic;
	
	signal Q_struct : std_logic;
	signal nQ_struct : std_logic;	 
	
	signal Q_beh : std_logic;
	signal nQ_beh : std_logic;
	
	signal Q_param : std_logic;
	signal nQ_param : std_logic;	
	
begin
	struct : entity RS_Latch(struct)
	port map (
		R => R,
		S => S,
		Q => Q_struct,
		nQ => nQ_struct
		);
	
	beh : entity RS_Latch(beh)
	port map (
		R => R,
		S => S,
		Q => Q_beh,
		nQ => nQ_beh
		);	  
	
	param : entity rs_latch(param)
	port map (
		R => R,
		S => S,
		Q => Q_param,
		nQ => nQ_param
		);
		
	Simulate: process
	begin
		R <= '0';
		S <= '0';
		wait for 10 ns;	 
		
		R <= '1';
		S <= '0';
		wait for 10 ns;	
		
		R <= '0';
		S <= '0';
		wait for 10 ns;	 
		
		R <= '0';
		S <= '1';
		wait for 10 ns;	  
		
		R <= '0';
		S <= '0';
		wait for 10 ns;		
		
		R <= '1';
		S <= '1';
		wait for 10 ns;	
		
		R <= '0';
		S <= '0';
		wait for 10 ns;
	end process;
	
end TB_ARCHITECTURE;

