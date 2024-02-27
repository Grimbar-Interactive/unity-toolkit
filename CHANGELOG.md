# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)

==
## [1.1.6] - 2024-02-26
### Modified
- Removed old define constraints.

## [1.1.5] - 2024-02-24
### Added
- Dependency resolution system
### Modified
- Updated package information
- Modified assemblies

## [1.1.4] - 2024-02-16
### Added
- New multi-variable functionality to BoolVariableListener.

## [1.1.3] - 2024-02-14
### Added
- Fixed scripting defines.

## [1.1.2] - 2024-02-13
### Added
- Added scripting defines.

## [1.1.1] - 2023-11-17
### Added
- Added BoolVariableListener behaviour.

## [1.1.0] - 2023-11-03
### Added
- PersistableVariable class added to allow saving of basic variable values.
### Changed
- DefaultedVariable<T> has been merged into Variable<T>.
### Removed
- All PlayerPref variables have been removed (BoolPrefVariable, etc).

## [1.0.6] - 2023-01-07
### Added
- QueueVariable is now a default variable type.

## [1.0.5] - 2022-11-11
### Updated
- Trying different method of running OnBegin and OnEnd events for ManagedObjects.

## [1.0.4] - 2022-11-08
### Added
- OnValueChanged callbacks for Variables (allows OnChangedEvent triggering from editor)
### Updated
- Updated Unity version to 2021.3

## [1.0.3] - 2022-11-07
### Updated
- ManagedObject now supporting editor callbacks again.

## [1.0.2] - 2022-07-26
### Updated
- ManagedObject now only uses OnEnable and OnDisable lifetime methods.

## [1.0.1] - 2022-06-29
### Added
- BoolVariable now has Toggle() method.

## [1.0.0] - 2022-01-14
### Added
- Initial creation of Unity-Variables.