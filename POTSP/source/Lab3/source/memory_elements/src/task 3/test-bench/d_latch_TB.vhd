library ieee;
use ieee.std_logic_1164.all;

entity d_latch_tb is
end d_latch_tb;

architecture TB_ARCHITECTURE of d_latch_tb is
	
	component d_latch
		port(
			D : in std_logic;
			Q : out std_logic;
			nQ : out std_logic );
	end component;
	
	signal D : std_logic := '0';
	
	signal Q_struct : std_logic;
	signal nQ_struct : std_logic;
	
	signal Q_beh : std_logic;
	signal nQ_beh : std_logic;	
	
	signal Q_param : std_logic;
	signal nQ_param : std_logic;
begin
	struct : entity d_latch(struct)
	port map (
		D => D,
		Q => Q_struct,
		nQ => nQ_struct
		); 
	
	beh : entity d_latch(beh)
	port map (
		D => D,
		Q => Q_beh,
		nQ => nQ_beh
		);	  
	
	param : entity d_latch(param)
	port map (
		D => D,
		Q => Q_param,
		nQ => nQ_param
		); 
	
	D <= not D after 100 ns;	
	
end TB_ARCHITECTURE;


