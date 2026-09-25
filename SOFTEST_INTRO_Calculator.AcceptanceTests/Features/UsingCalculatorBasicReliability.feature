@BasicMusa
Feature: UsingCalculatorBasicReliability
    In order to understand how failure intensity decreases as failures are corrected
    As a reliability engineer
    I want to calculate Basic Musa failure intensity and cumulative failures

Scenario Outline: Calculating current failure intensity
    Given I have a calculator
    And the Basic Musa parameters are
      | lambda0   | nu0     | tau     |
      | <lambda0> | <nu0>   | <tau>   |
    When I calculate the current failure intensity
    Then the result should be approximately <lambda>

    Examples:
      | lambda0 | nu0  | tau | lambda            |
      | 10      | 1000 | 0   | 10                |
      | 10      | 1000 | 100 | 3.678794411714423 |

Scenario Outline: Calculating expected cumulative failures
    Given I have a calculator
    And the Basic Musa parameters are
      | lambda0   | nu0     | tau     |
      | <lambda0> | <nu0>   | <tau>   |
    When I calculate the expected cumulative number of failures
    Then the result should be approximately <mu>

    Examples:
      | lambda0 | nu0  | tau | mu                |
      | 10      | 1000 | 0   | 0                 |
      | 10      | 1000 | 100 | 632.1205588285577 |

Scenario Outline: Rejecting invalid Basic Musa parameters
    Given I have a calculator
    And the Basic Musa parameters are
      | lambda0   | nu0     | tau     |
      | <lambda0> | <nu0>   | <tau>   |
    When I try to calculate the current failure intensity
    Then the calculator should reject the input

    Examples:
      | lambda0 | nu0  | tau |
      | 0       | 1000 | 10  |
      | -5      | 1000 | 10  |
      | 10      | 0    | 10  |
      | 10      | -5   | 10  |
      | 10      | 1000 | -1  |