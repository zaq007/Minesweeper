#if 0

// gaussian variance=6

#define B_P0  -7.23746
#define B_P1  -5.30294
#define B_P2  -3.37754
#define B_P3  -1.45843
#define B_P4   0.45843
#define B_P5   2.37754
#define B_P6   4.30294
#define B_P7   6.23746

#define B_W0 0.00632309
#define B_W1 0.0432643
#define B_W2 0.155584
#define B_W3 0.294828
#define B_W4 0.294828
#define B_W5 0.155584
#define B_W6 0.0432643
#define B_W7 0.00632309

#elif 1

// gaussian variance=20
#define B_P0    -7.41338
#define B_P1    -5.43782
#define B_P2    -3.46257
#define B_P3    -1.4875
#define B_P4    0.487503
#define B_P5    2.46257
#define B_P6    4.43782
#define B_P7    6.41338

#define B_W0    0.0570498
#define B_W1    0.103181
#define B_W2    0.153163
#define B_W3    0.186607
#define B_W4    0.186607
#define B_W5    0.153163
#define B_W6    0.103181
#define B_W7    0.0570498

#else

#define B_P0    -7.5
#define B_P1    -5.5
#define B_P2    -3.5
#define B_P3    -1.5
#define B_P4     0.5
#define B_P5     2.5
#define B_P6     4.5
#define B_P7     6.5

#define B_W0     0
#define B_W1     (1.0/6)
#define B_W2     (1.0/6)
#define B_W3     (1.0/6)
#define B_W4     (1.0/6)
#define B_W5     (1.0/6)
#define B_W6     (1.0/6)
#define B_W7     0

#endif
