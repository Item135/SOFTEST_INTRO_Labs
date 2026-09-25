@Factorials
    Feature: UsingCalculatorFactorial
    In order to factorize everything
    As a factorial operator
    I want to find factorial operations quickly

Scenario Outline: Factorise one numbers
    Given I have a calculator
    When I have entered <number> into the calculator and press factorial
    Then the result should be <facanswer>

    Examples:
    | number | facanswer |
    | 5 | 120 |
    | 8 | 40320 |

Scenario: Factorise zero
    Given I have a calculator
    When I have entered 0 into the calculator and press factorial
    Then the result should be 1

Scenario Outline: Reject negative factorial
    Given I have a calculator
    When I have entered out of bound <number> into the calculator and press factorial
    Then factorial should be rejected
    
    Examples:
    | numerator |
    | -1 |
    | 22 |