@Availability
Feature: UsingCalculatorAvailability
    In order to calculate MTBF and Availability
    As someone who struggles with maths
    I want to be able to use my calculator to do this

Scenario: Calculating MTBF
    Given I have a calculator
    When I have entered <numerator> and <divisor> into the calculator and press MTBF
    Then the result should be <quotient>

Scenario: Calculating Availability
    Given I have a calculator
    When I have entered <MTBF> and <MTTR> into the calculator and press Availability
    Then the result should be <availability>

Scenario: Calculating Availability from named reliability values
    Given I have a calculator
    And the reliability values are
    | MTBF | MTTR |
    | 90 | 10 |
    When I calculate Availability from these values
    Then the result should be 0.9