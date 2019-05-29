library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity D_Enable_Latch is
	port (
		D, E : in std_logic;
		Q : out std_logic;
		nQ : out std_logic
		);
end D_Enable_Latch;

architecture struct of D_Enable_Latch is 
	component nor2 
		port (
			A, B: in std_logic;
			R : out std_logic);
	end component;
	component inv
		port (
			A: in std_logic;
			nA: out std_logic);
	end component;
	component and2 
		port (
			A, B: in std_logic;
			R : out std_logic);
	end component;
	signal d_t, ea_t, n_t1, n_t2, da_t : std_logic;
begin
	U1: and2 port map (A => E, B => D, R => ea_t);
	U2: inv port map (A => D, nA => d_t);
	U3: and2 port map (A => d_t, B => e, R => da_t);
	U4: entity nor2(beh) port map (A => ea_t,B => n_t2, R => n_t1);
	U5: entity nor2(beh) port map (A => da_t, B => n_t1, R => n_t2);
	Q <= n_t2;
	nQ <= n_t1;
end struct;

architecture beh of D_Enable_Latch is
	signal data : std_logic;
begin	
	data <= D when (E = '1');
	Q <= data;
	nQ <= not data;
end beh;

architecture param of D_Enable_Latch is
	signal data : std_logic;
begin
	data <= D when (E = '1');
	Q <= data after 2 ns;
	nQ <= not data after 3 ns;
end param;