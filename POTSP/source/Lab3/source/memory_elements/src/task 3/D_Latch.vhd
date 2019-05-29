library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity D_Latch is
	port (
		D : in std_logic;
		Q : out std_logic;
		nQ : out std_logic
		);
end D_Latch;

architecture struct of D_Latch is 
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
	signal t1, t2, t3 : std_logic;
begin
	U1: inv port map (A => D, nA => t3);
	U2: entity nor2(beh) port map (A => D, B => t2, R => t1);
	U3: entity nor2(beh) port map (A => t3, B => t1, R => t2);
	Q <= t2;
	nQ <= t1;
end struct;

architecture beh of D_Latch is
	signal t1, t2, inversed: std_logic;
begin					   
	inversed <= not D;
	t2 <= D nor t1;
	t1 <= inversed nor t2;
	nQ <= t1;
	Q <= t2;
end beh;	   

architecture param of D_Latch is
	signal t1, t2, inversed: std_logic;
begin
	inversed <= not D;
	t2 <= D nor t1 after 3 ns;
	t1 <= inversed nor t2 after 3 ns;
	Q <= transport t2 after 2 ns;
	nQ <= transport t1 after 3 ns;	
end param;